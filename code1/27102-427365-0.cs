    private void ProcessRequest(IAsyncResult result)
            {
                HttpListener listener = (HttpListener)result.AsyncState;
                HttpListenerContext context = listener.EndGetContext(result);
    
                string responseString = "<html>Hello World</html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
    
                //One
                context.Response.AddHeader("Server", "My Personal Server");
                //Two
                context.Response.Headers.Remove(HttpResponseHeader.Server);
                context.Response.Headers.Add(HttpResponseHeader.Server, "My Personal Server");
                //Three
                context.Response.Headers.Set(HttpResponseHeader.Server, "My Personal Server");
                System.IO.Stream output = context.Response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
    
                Listener.BeginGetContext(ProcessRequest, Listener);
            }
