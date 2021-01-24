            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = x =>
                {   
                    if (x.Context.Request.Path.Value.StartsWith("/images/"))
                    {
                        using (var sr = File.OpenRead(path))
                        {             
                            HttpResponse hr = x.Context.Response;
                            hr.ContentLength = sr.Length;
                            sr.CopyTo(x.Context.Response.Body);
                        }
                    }
                }
            });       
