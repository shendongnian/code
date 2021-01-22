        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                byte[] output = DoWork("Http://localhost/test.pdf");
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment");
                Response.AddHeader("content-length", output.Length.ToString());
                Response.BinaryWrite(output);
                Response.End();
            }
        }
        public byte[] DoWork(string requestUrl)
        {
            byte[] responseData;
            HttpWebRequest req = null;
            HttpWebResponse resp = null;
            StreamReader strmReader = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(requestUrl);
                using (resp = (HttpWebResponse)req.GetResponse())
                {
                    byte[] buffer = new byte[resp.ContentLength];
                    using (BinaryReader reader = new BinaryReader(resp.GetResponseStream()))
                    {
                        buffer = reader.ReadBytes(buffer.Length);
                        reader.Close();
                    }
                    responseData = buffer;
                }
            }
            finally
            {
                if (req != null)
                {
                    req = null;
                }
                if (resp != null)
                {
                    resp.Close();
                    resp = null;
                }
            }
            return responseData;
        }
