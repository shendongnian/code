    using System.Net;
    using System.Text;
    using System.IO;
    using System;
    
    namespace Botnet
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine(Post("http://www.example.com/recepticle.aspx", "thing1=hello&thing2=world"));
                }
                catch (WebException webException)
                {
                    Console.WriteLine(webException);
                }
                finally
                {
                    Console.ReadLine();
                }
            }
    
            public static string Post(string requestUriString, string s)
            {
                var request = (HttpWebRequest)WebRequest.Create(requestUriString);
                var data = Encoding.ASCII.GetBytes(s);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
    
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
    
                try
                {
                    var response = (HttpWebResponse)request.GetResponse();
                    return new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
                catch (WebException webException)
                {
                    Console.WriteLine(webException);
                    throw;
                }
            }
        }
    }
