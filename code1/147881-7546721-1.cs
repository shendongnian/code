    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Collections.Generic;
    
    public class Handler : IHttpHandler
    {
        string dns = "dc1"; //set to your own dns server
        string domain = "";
        int qtype = 15; //mx records
    
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
    
            try
            {
                domain = context.Request["d"];
                if (string.IsNullOrEmpty(domain)) throw new Exception("Add ?d=<domain name> to url or post data");
    
                Do(context);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "131") msg = "Not found";
                else if (msg == "4") msg = "Malformed";
    
                context.Response.Write(msg);
            }
        }
    
        public void Do(HttpContext context)
        {
            UdpClient udpc = new UdpClient(dns, 53);
    
            // SEND REQUEST--------------------
            List<byte> list = new List<byte>();
            list.AddRange(new byte[] { 88, 89, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
            
            string[] tmp = domain.Split('.');
            foreach (string s in tmp)
            {
                list.Add(Convert.ToByte(s.Length));
                char[] chars = s.ToCharArray();
                foreach (char c in chars)
                    list.Add(Convert.ToByte(Convert.ToInt32(c)));
            }
            list.AddRange(new byte[] { 0, 0, Convert.ToByte(qtype), 0, 1 });
    
            byte[] req = new byte[list.Count];
            for (int i = 0; i < list.Count; i++) { req[i] = list[i]; }
    
            udpc.Send(req, req.Length);
    
    
            // RECEIVE RESPONSE--------------
            IPEndPoint ep = null;
            byte[] bresp = udpc.Receive(ref ep);
            udpc.Close();
    
            int[] resp = new int[bresp.Length];
            for (int i = 0; i < resp.Length; i++)
                resp[i] = Convert.ToInt32(bresp[i]);
    
            int status = resp[3];  //128 found  131 not found
            if (status != 128) throw new Exception(string.Format("{0}", status));
            int answers = resp[7];
            if (answers == 0) throw new Exception("No results");
    
            int start = domain.Length + 18;
            while (answers > 0)
            {
                int pref = resp[start + 13];
                string str = GetDom(resp, ref start);
                context.Response.Write(string.Format("{0}: {1}\n", pref, str));
    
                answers--;
            }
        }
    
        //------------------------------------------------------
        private string GetDom(int[] arr, ref int start)
        {
            StringBuilder sb = new StringBuilder();
    
            start += 14; //offset
            int len = arr[start];
            while (len > 0)
            {
                if (sb.Length > 0) sb.Append(".");
    
                for (int i = start; i < start + len; i++)
                    sb.Append(Convert.ToChar(arr[i + 1]));
    
                start += len + 1;
                len = arr[start];
    
                if (len == 192)
                {
                    sb.Append("." + domain);
                    start++;
                    break;
                }
            }
            start++;
            return sb.ToString();
        }
    
        //------------------------------------------------------
        public bool IsReusable { get { return false; } }
    }
