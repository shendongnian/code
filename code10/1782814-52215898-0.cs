    try
                {
                    string webAddr = "URL/ImportSet";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + "TOKEN NO");
                    httpWebRequest.ContentType = "application/json; charset=utf-8";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = "{\"BasicInformation\":{\"BranchName\":\"Abc\",\"DateFrom\":\"20180905\",\"DateTo\":\"20180905\"},\"Details\":\"\",\"Header\":{\"Company\":\"C001\",\"BranchCode\":\"ABC123\"}}";
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var responseText = streamReader.ReadToEnd();
                        textBox1.Text = responseText.ToString();
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
