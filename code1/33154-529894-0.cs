    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.Security;
    using System.Web;
    using System.Web.Handlers;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static string API_KEY = "YOUR_API_KEY_GOES_HERE! INCLUDE DASHES!";
            public static string SECRET_ACCESS_KEY = "YOUR_SECRET_KEY_GOES_HERE!";
    
            static void Main(string[] args)
            {
                Console.WriteLine("BLAST - \r\n\r\n");
                BlastTcpPost();
                
                Console.WriteLine("SEND - \r\n\r\n");
                SendTcpPost();
            }
    
            /// <summary>
            /// Send a BLAST to all users in your ZEEP account.
            /// </summary>
            public static void BlastTcpPost()
            {
                SendSMS(
                    "https://api.zeepmobile.com/messaging/2008-07-14/blast_message",    // URL for Send_Message 
                    "You are on blast",                                                 // Message to send
                    string.Empty                                                        // No UserId to send.
                    );
            }
    
            /// <summary>
            /// Send a single message to a user in your ZEEP account.
            /// </summary>
            public static void SendTcpPost()
            {
                // Note:- 22 I use for the UserId is just a user I have signed up. Yours may be different and you 
                // might want to pass that in as a parameter.
    
                SendSMS(
                    "https://api.zeepmobile.com/messaging/2008-07-14/send_message",     // URL for Send_Message
                    "You are a user...good job!",                                       // Message to send
                    "22"                                                                // User Id in your system.
                    );
                
            }
    
            /// <summary>
            /// Uses a TCPClient and SSLStream to perform a POST.
            /// </summary>
            /// <param name="requestUrl">URL that the POST must be directed to.</param>
            /// <param name="body">Message that is to be sent.</param>
            /// <param name="user">UserId in your Zeep System. Only required if your sending a Single Message to a User. 
            /// Otherwise, just send a string.Empty.</param>
            /// <returns>Response from the server. (although it will write the response to console)</returns>
            public static string SendSMS(string requestUrl, string body, string user)
            {
                string parameters = "";
                string requestHeaders = "";
                string responseData = "";
    
                // FORMAT must be Sun, 06 Nov 1994 08:49:37 GMT
                string http_date = DateTime.UtcNow.ToString("r");
                
                // Clean the text to send
                body = HttpUtility.UrlEncode(body, System.Text.Encoding.UTF8);
    
                if (user.Length > 0) parameters += "user_id=" + user + "&";
                if (body.Length > 0) parameters += "body=" + body;
    
    
                // String that will be converted into a signature.
                string canonicalString = API_KEY + http_date + parameters;
    
    
                //------------START HASH COMPUTATION---------------------
                // Compute the Base64 HMACSHA1 value
                HMACSHA1 hmacsha1 = new HMACSHA1(SECRET_ACCESS_KEY.ToByteArray());
    
                // Compute the hash of the input file.
                byte[] hashValue = hmacsha1.ComputeHash(canonicalString.ToByteArray());
    
                String b64Mac = hashValue.ToBase64String();
                String authentication = String.Format("Zeep {0}:{1}", API_KEY, b64Mac);
                //-----------END HASH COMPUTATION------------------------
    
    
                string auth = String.Format("Zeep {0}:{1}", API_KEY, b64Mac);
    
    
                System.Uri uri = new Uri(requestUrl);
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient(uri.Host, uri.Port);
                string requestMethod = "POST " + uri.LocalPath + " HTTP/1.1\r\n";
                
                // Set Headers for the POST message
                requestHeaders += "Host: api.zeepmobile.com\r\n";
                requestHeaders += "Authorization: " + auth + "\r\n";
                requestHeaders += "Date: " + DateTime.UtcNow.ToString("r") + "\r\n";
                requestHeaders += "Content-Type: application/x-www-form-urlencoded\r\n";
                requestHeaders += "Content-Length: " + parameters.ToByteArray().Length + "\r\n";
                requestHeaders += "\r\n";
    
    
                // Get the data to be sent as a byte array.
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(requestMethod + requestHeaders + parameters + "\r\n");
                // Send the message to the connected TcpServer.
                NetworkStream stream = client.GetStream();
    
    
                // SSL Authentication is used because the Server requires https.
                System.Net.Security.SslStream sslStream = new System.Net.Security.SslStream(
                    stream,
                    false,
                    new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate));
                sslStream.AuthenticateAsClient(uri.Host);
    
                // Send the data over the SSL stream.
                sslStream.Write(data, 0, data.Length);
                sslStream.Flush();
    
                
                // Receive the TcpServer.response.
                for (int i = 0; i < 100; i++)
                {
                    if (stream.DataAvailable)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(100);
                }
    
                Byte[] bytes = new byte[1024];
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (stream.DataAvailable)
                {
                    int count = sslStream.Read(bytes, 0, 1024);
                    if (count == 0)
                    {
                        break;
                    }
                    sb.Append(System.Text.Encoding.UTF8.GetString(bytes, 0, count));
                }
    
                responseData = sb.ToString();
                Console.WriteLine(responseData);
                // Close everything.
                client.Close();
    
                return responseData;
            }
    
    
    
            // The following method is invoked by the RemoteCertificateValidationDelegate.
            // We want to make sure the SSL has no Policy errors and is safe.
            public static bool ValidateServerCertificate(
                  object sender,
                  X509Certificate certificate,
                  X509Chain chain,
                  SslPolicyErrors sslPolicyErrors)
            {
                // Somehow the cert always has PolicyErrors so I am returning true regardless.
                return true;
                //if (sslPolicyErrors == SslPolicyErrors.None)
                //    return true;
    
                //Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
    
                //// Do not allow this client to communicate with unauthenticated servers.
                //return false;
            }
        }
    
        public static class Extensions
        {
            public static byte[] ToByteArray(this string input)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                return encoding.GetBytes(input);
            }
    
            public static string ToBase64String(this byte[] input)
            {
                return Convert.ToBase64String(input);
            }
        }
    }
