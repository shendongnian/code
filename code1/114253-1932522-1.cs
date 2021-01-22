    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Text.RegularExpressions;
    public string SaveImageFile(FileUpload fu, string directoryPath, int MaxWidth, 
                                int MaxHeight, string prefixName)
    {
        string serverPath = "", returnString = "";
        if (fu.HasFile)
        {
            Byte[] bytes = fu.FileBytes;
            //Int64 len = 0;
            prefixName = "Testing" + prefixName;
            //directoryPath = "Testing/";
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            string dipath = System.Web.HttpContext.Current.Server.MapPath("~/") + directoryPath;
            DirectoryInfo di = new DirectoryInfo(dipath);
            if (!(di.Exists))
            {
                di.Create();
            }
            HttpPostedFile file = fu.PostedFile;
            DateTime oldTime = new DateTime(1970, 01, 01, 00, 00, 00);
            DateTime currentTime = DateTime.Now;
            TimeSpan structTimespan = currentTime - oldTime;
            prefixName += ((long)structTimespan.TotalMilliseconds).ToString();
            if (IsImage(file))
            {
                using (Bitmap bitmap = new Bitmap(file.InputStream, false))
                {
                    serverPath = dipath + "//" + prefixName +     fu.FileName.Substring(fu.FileName.IndexOf("."));
                    img.Save(serverPath);
                    returnString = "~/" + directoryPath + "//" + prefixName + fu.FileName.Substring(fu.FileName.IndexOf("."));
                }
            }
        }
        return returnString;
    }
    private bool IsImage(HttpPostedFile file)
    {
        if (file != null && Regex.IsMatch(file.ContentType, "image/\\S+") &&
          file.ContentLength > 0)
        {
            return true;
        }
        return false;
    }
