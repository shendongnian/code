        public static bool Upload(string webUrl, string documentName, byte[] bytes, Dictionary<string, object> metaInfo, out string result)
        {
            string putOption = "overwrite,createdir,migrationsemantics";  // see http://msdn2.microsoft.com/en-us/library/ms455325.aspx 
            string comment = null;
            bool keepCheckedOut = false; 
            string method = "method=put+document%3a12.0.4518.1016&service_name=%2f&document=[document_name={0};meta_info=[{1}]]&put_option={2}&comment={3}&keep_checked_out={4}\n"; 
            method = String.Format(method, documentName, EncodeMetaInfo(metaInfo), putOption, HttpUtility.UrlEncode(comment), keepCheckedOut.ToString().ToLower()); 
            List<byte> data = new List<byte>();
            data.AddRange(Encoding.UTF8.GetBytes(method));
            data.AddRange(bytes); 
            try 
            { 
                using (WebClient webClient = new WebClient()) 
                { 
                    webClient.Credentials = CredentialCache.DefaultCredentials; 
                    webClient.Headers.Add("Content-Type", "application/x-vermeer-urlencoded");
                    webClient.Headers.Add("X-Vermeer-Content-Type", "application/x-vermeer-urlencoded");
                    result = Encoding.UTF8.GetString(webClient.UploadData(webUrl + "/_vti_bin/_vti_aut/author.dll", "POST", data.ToArray()));
                    if (result.IndexOf("\n<p>message=successfully") < 0)   
                        throw new Exception(result);
                } 
            }
            catch (Exception ex)
            { 
                result = ex.Message; 
                return false; 
            }
            return true;
        }
