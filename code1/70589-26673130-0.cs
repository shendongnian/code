    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    using System.IO;
     
    public partial class download_file_from_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://4rapiddev.com/wp-includes/images/logo.jpg";
            string file_name = Server.MapPath(".") + "\\logo.jpg";
     
            save_file_from_url(file_name, url);
     
            Response.Write("The file has been saved at: " + file_name);
        }
     
        public void save_file_from_url(string file_name, string url)
        {
            byte[] content;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
     
            Stream stream = response.GetResponseStream();
     
            using (BinaryReader br = new BinaryReader(stream))
            {
                content = br.ReadBytes(500000);
                br.Close();
            }
            response.Close();
     
            FileStream fs = new FileStream(file_name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(content);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
    }
