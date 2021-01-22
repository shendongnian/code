    using System;
    using System.Net;
    
    class Test
    {
        static void Main()
        {
            WebRequest request = WebRequest.Create("ftp://host.com/directory");
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential("user", "pass");
            using (var resp = (FtpWebResponse) request.GetResponse())
            {
                Console.WriteLine(resp.StatusCode);
            }
        }
    }
