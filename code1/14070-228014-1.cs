                //POST param
                if (webRequest.Method == "POST")
                {
                    StreamReader getPostParam = new StreamReader(request.InputStream, true);
                    postData = getPostParam.ReadToEnd();
                    byte[] postBuffer = System.Text.Encoding.Default.GetBytes(postData);
                    postDataStream.Write(postBuffer, 0, postBuffer.Length);
                    postDataStream.Close();
                }
                //END POST param
