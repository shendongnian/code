    var content = new ByteArrayContent(filedata);
                content.Headers.ContentType = new MediaTypeHeaderValue(BE.Common.ContentType.appjson);
    
                using (var client = new HttpClient())
                {
                    aPIRequestfile.FileName = filename;
                    aPIRequestfile.UserId = CurrentSession.Instance.VerifiedUser.UserDetailId;
                    aPIRequestfile.ContentType = contentType;
                    aPIRequestfile.IsProfile = isProfile;
                    client.DefaultRequestHeaders.Add("FileDetails", JsonConvert.SerializeObject(aPIRequestfile));
                    var ApiRequest = client.PostAsync(apiUrl, content);
                    if (ApiRequest != null)
                    {
                        if (ApiRequest.Result.StatusCode == HttpStatusCode.OK)
                        {
                            RepsonseMsg = ApiRequest.Result.Content.ReadAsStringAsync().Result;
                            
                        }
                        else
                            RepsonseMsg = BE.ResultStatus.Failed.ToString();
                    }
                }
