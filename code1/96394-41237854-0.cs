                try
                {
                    //Do Somthing
                    break;
                }
                catch (Exception ex)
                {
                    if (--retries == 0)
                        return Request.BadRequest(ApiUtil.GenerateRequestResponse(false, "3 Times tried it failed do to : " + ex.Message, new JObject()));
                    else
                        System.Threading.Thread.Sleep(100);
                }
