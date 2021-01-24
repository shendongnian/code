    using System;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    
    public class FTPDownloader : MonoBehaviour
    {
    
        public bool editorDownload;
        public string savePath;
        public string saveDir;
        public string username;
        public string pswd;
    
        public void StartDownload(string serverIP, string serverFolder, string fileName)
        {
            string url = string.Format("{0}{1}{2}{3}", "ftp://", serverIP, serverFolder, fileName);
            Task task = new Task(() =>
            {
                Download(url, fileName);
            });
            task.Start();
        }
    
        void Download(string url, string fileName)
        {
            if (!editorDownload)
            {
                return;
            }
            string path = Path.Combine(saveDir, fileName);
    
            try
            {
                if(File.Exists(path))
                {
                    //already downloaded
                    return;
                }
                //Debug.Log(url);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, pswd);
    
                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(path))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    int total = 0;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        total += read;
                    }
                }
            }
            catch (Exception e)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                //Debug.Log(e.ToString());
            }
        }
    }
