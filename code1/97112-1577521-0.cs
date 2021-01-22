       HttpWorkerRequest workerRequest = (HttpWorkerRequest)context.GetType().GetProperty("WorkerRequest",  BindingFlags.Instance | BindingFlags.NonPublic).GetValue(context, null);
            // Indicates if the worker request has a body
            
            if (workerRequest.HasEntityBody())
            {
                // Get the byte size of the form post. 
               long contentLength = long.Parse((workerRequest.GetKnownRequestHeader(HttpWorkerRequest.HeaderContentLength)));
                if (contentLength > MAX_UPLOAD_FILE_SIZE * 1024 )
                      {
                       workerRequest.CloseConnection();
                       context.Response.Redirect(SomeErrorPage);
                      }
            }
