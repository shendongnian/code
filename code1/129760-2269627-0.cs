            DateTime startTime = DateTime.UtcNow;
            WebRequest request = WebRequest.Create("http://www.example.com/largefile");
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream()) {
                using (Stream fileStream = File.OpenWrite("c:\temp\largefile")) {
                    byte[] buffer = new byte[4096];
                    int bytesRead = responseStream.Read(buffer, 0, 4096);
                    while (bytesRead > 0) {
                        fileStream.Write(buffer, 0, bytesRead);
                        DateTime nowTime = DateTime.UtcNow;
                        if ((nowTime - startTime).TotalMinutes > 5) {
                            throw new ApplicationException(
                                "Download timed out");
                        }
                        bytesRead = responseStream.Read(buffer, 0, 4096);
                    }
                }
            }
