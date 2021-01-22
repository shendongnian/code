     if (Request.Params[param] != nul)
                {
                   ...
                }
                else
                {
                    Response.ContentType = "text/html";
                    Response.Write("Authentication error");
                    Response.StatusCode = 401;
                    Response.End();
                }
