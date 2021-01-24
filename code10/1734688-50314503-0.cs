    public void sendCurlRequest(string url, bool post, string post_aata, bool cookies)
            {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
                Easy easy = new Easy();
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
                string writingData = string.Empty;
                easy.SetOpt(CURLoption.CURLOPT_URL, instagramUrl + url);
            
                easy.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, 1);
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, 0);
                easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, 0);
                if (post)
                {
                    easy.SetOpt(CURLoption.CURLOPT_POST, 1);
                    File.WriteAllText("D:\\cookies\\post_data.txt", System.Web.HttpUtility.UrlEncode(post_aata));
                    easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, post_aata);
                }
                if (cookies)
                {
                    easy.SetOpt(CURLoption.CURLOPT_COOKIEFILE, "\cookies.txt");
                }
                else
                {
                    easy.SetOpt(CURLoption.CURLOPT_COOKIEJAR, "cookies.txt");
                }
                var c = easy.Perform();
                int info = 0;
                CURLcode code = easy.GetInfo(CURLINFO.CURLINFO_RESPONSE_CODE, ref info);
                easy.Cleanup();
                Curl.GlobalCleanup();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
