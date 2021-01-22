    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Collections.Generic;
    
    public class Handler : IHttpHandler
    {
        string dns = "dc1";  //change to your dns
        string qtype = "15"; //A=1  MX=15
        string domain = "";
        int[] resp;
    
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
    
            try
            {
                if (context.Request["t"] != null) qtype = context.Request["t"];
                if (context.Request["d"] != null) domain = context.Request["d"];
    
                if (string.IsNullOrEmpty(domain)) throw new Exception("Add ?d=<domain name> to url or post data");
    
                Do(context);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg == "1") msg = "Malformed packet";
                else if (msg == "5") msg = "Refused";
                else if (msg == "131") msg = "No such name";
    
                context.Response.Write("Error: " + msg);
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
            byte[] recv = udpc.Receive(ref ep);
            udpc.Close();
    
            resp = new int[recv.Length];
            for (int i = 0; i < resp.Length; i++)
                resp[i] = Convert.ToInt32(recv[i]);
    
            int status = resp[3];
            if (status != 128) throw new Exception(string.Format("{0}", status));
            int answers = resp[7];
            if (answers == 0) throw new Exception("No results");
    
            int pos = domain.Length + 18;
            if (qtype == "15") // MX record
            {
                while (answers > 0)
                {
                    int preference = resp[pos + 13];
                    pos += 14; //offset
                    string str = GetMXRecord(pos, out pos);
                    context.Response.Write(string.Format("{0}: {1}\n", preference, str));
                    answers--;
                }
            }
            else if (qtype == "1") // A record
            {
                while (answers > 0)
                {
                    pos += 11; //offset
                    string str = GetARecord(ref pos);
                    context.Response.Write(string.Format("{0}\n", str));
                    answers--;
                }
            }
        }
    
        //------------------------------------------------------
        private string GetARecord(ref int start)
        {
            StringBuilder sb = new StringBuilder();
    
            int len = resp[start];
            for (int i = start; i < start + len; i++)
            {
                if (sb.Length > 0) sb.Append(".");
                sb.Append(resp[i + 1]);
            }
            start += len + 1;
            return sb.ToString();
        }
        private string GetMXRecord(int start, out int pos)
        {
            StringBuilder sb = new StringBuilder();
            int len = resp[start];
            while (len > 0)
            {
                if (len != 192)
                {
                    if (sb.Length > 0) sb.Append(".");
                    for (int i = start; i < start + len; i++)
                        sb.Append(Convert.ToChar(resp[i + 1]));
                    start += len + 1;
                    len = resp[start];
                }
                if (len == 192)
                {
                    int newpos = resp[start + 1];
                    if (sb.Length > 0) sb.Append(".");
                    sb.Append(GetMXRecord(newpos, out newpos));
                    start++;
                    break;
                }
            }
            pos = start + 1;
            return sb.ToString();
        }
    
        //------------------------------------------------------
        public bool IsReusable { get { return false; } }
    }
