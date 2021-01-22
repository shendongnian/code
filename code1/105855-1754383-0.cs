    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.IO" %>
    
    <script runat="server" language="c#">
        public void Page_Load()
        {
            try
            {
                Response.Clear();
                Response.ContentType = "image/jpeg";
                string filename = Page.Request.QueryString["file"];
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    int streamLength = (int)stream.Length;
                    byte[] buffer = new byte[streamLength];
                    stream.Read(buffer, 0, streamLength);
                    Response.BinaryWrite(buffer);
                }
            }
            finally
            {
                Response.End();
            }
        }
    </script>
