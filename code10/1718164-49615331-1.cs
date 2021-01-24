            List<string> files = new List<String>();
            files.Add(@"C:\Test1.txt");
            files.Add(@"C:\Test2.txt");
            using (Stream requestStream = request.GetRequestStream())
            {
                files.ForEach(fileName =>
                {
                    byte[] buffer = null;
                    int bytesRead = 0;
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        buffer = new Byte[checked((uint)Math.Min(1024, (int)fs.Length))];
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            requestStream.Write(buffer, 0, bytesRead);
                        }
                        requestStream.Flush();
                    }
                });
            }
