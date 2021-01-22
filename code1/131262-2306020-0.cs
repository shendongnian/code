    public string solveCaptcha(String username, String password)
        {
            String boundry = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            StringBuilder postData = new StringBuilder();
            postData.AppendLine("--" + boundry);
            postData.AppendLine("Content-Disposition: form-data; name=\"function\"");
            postData.AppendLine("");
            postData.AppendLine("picture2");
            postData.AppendLine("--" + boundry);
            postData.AppendLine("Content-Disposition: form-data; name=\"username\"");
            postData.AppendLine("");
            postData.AppendLine(username);
            postData.AppendLine("--" + boundry);
            postData.AppendLine("Content-Disposition: form-data; name=\"password\"");
            postData.AppendLine("");
            postData.AppendLine(password);
            postData.AppendLine("--" + boundry);
            postData.AppendLine("Content-Disposition: form-data; name=\"pict\"; filename=\"pic.jpeg\"");
            postData.AppendLine("Content-Type: image/pjpeg");
            postData.AppendLine("");
            StringBuilder postData2 = new StringBuilder();
            postData2.AppendLine("\n--" + boundry);
            postData2.AppendLine("Content-Disposition: form-data; name=\"pict_to\"");
            postData2.AppendLine("");
            postData2.AppendLine("0");
            postData2.AppendLine("--" + boundry);
            postData2.AppendLine("Content-Disposition: form-data; name=\"pict_type\"");
            postData2.AppendLine("");
            postData2.AppendLine("0");
            postData2.AppendLine("--" + boundry + "--");
            Byte[] fileOpen = File.ReadAllBytes("C:/pic.jpeg");
            byte[] buffer = Encoding.ASCII.GetBytes(postData.ToString());
            byte[] buffer2 = Encoding.ASCII.GetBytes(postData2.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://poster.decaptcher.com/");
            request.ContentType = "multipart/form-data; boundary=" + boundry;
            request.ContentLength = buffer.Length + buffer2.Length + fileOpen.Length;
            request.Method = "POST";
            String source = "";
            using (Stream PostData = request.GetRequestStream())
            {
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Write(fileOpen, 0, fileOpen.Length);
                PostData.Write(buffer2, 0, buffer2.Length);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Byte[] rBuf = new Byte[8192];
                    Stream resStream = response.GetResponseStream();
                    string tmpString = null;
                    int count = 0;
                    do
                    {
                        count = resStream.Read(rBuf, 0, rBuf.Length);
                        if (count != 0)
                        {
                            tmpString = Encoding.ASCII.GetString(rBuf, 0, count);
                            source += tmpString;
                        }
                    } while (count > 0);
                }
            }
            MessageBox.Show(source);
            // Do something with the source
            return source;
        }
