    <%@ Page Language="C#" %>
    <%@ Import Namespace="System" %>
    <%@ Import Namespace="System.IO" %>
    
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e) 
        {
            string path = "/txtfiles/" + Request.Form["file_name"];
            if (!File.Exists(path)) 
            {
                using (StreamWriter sw = File.CreateText(path)) 
                {
                    sw.WriteLine(Request.Form["seatsArray"]);
                    sw.WriteLine("");
                }   
            }
    
            using (StreamReader sr = File.OpenText(path)) 
            {
                string s = "";
                while ((s = sr.ReadLine()) != null) 
                {
                    Response.Write(s);
                }
            }
        }
    </script>
