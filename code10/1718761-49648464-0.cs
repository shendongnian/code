     var context = _listener.GetContext();
                            try
                            {
    
                                var request = context.Request;
                                using (var reader = new StreamReader(request.InputStream,
                                    request.ContentEncoding))
                                {
                                    var text = reader.ReadToEnd();
                                    Console.WriteLine("Messages ************");
                                    Console.WriteLine(text);
                                    publisher.SendMessages(text);
                                }
                            }
                            catch(Exception ex)
                            {
                                
                            }
                            finally
                            {
                               
                                context.Request.InputStream.Close();
                            }
