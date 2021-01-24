     [HttpGet]
            [Route("api/Order/{id}/Download/Ricetta")]
            public async Task<HttpResponseMessage> GetBookForHRM([FromUri] string id)
            {
                try
                {
    
                    if (string.IsNullOrEmpty(id)) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
    
                    var order = await _orderService.FindAsync(xx => xx.Id == id);
                    if (order == null) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
    
                    if (string.IsNullOrEmpty(order.RicettaUrl)) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
    
                    var user = await _aspNetService.FindAsync(xx => xx.Id == order.IdUser);
                    if (user == null) return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
    
                    var fileWithPath = $@"{user.GetUserRicettaDirectory()}/{order.RicettaUrl}";
    
                    //converting Pdf file into bytes array  
                    var dataBytes = File.ReadAllBytes(fileWithPath);
                    //adding bytes to memory stream   
                    var dataStream = new MemoryStream(dataBytes);
    
                    HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                    httpResponseMessage.Content = new StreamContent(dataStream);
                    httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                    httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = order.RicettaUrl.Trim()
                    };
                    httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
    
                    return httpResponseMessage;
                }
                catch (Exception ex)
                {
                    _logger.LogException(ex);
                    throw;
                }
            }
