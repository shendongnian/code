        private void Receive(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                bytesRead = tcpClient.GetStream().EndRead(ar);
            }
            catch (Exception e)
            {
                //something bad happened. Cleanup required
                return;
            }
            if (bytesRead != 0)
            {
                char[] charBuffer = utf8Encoding.GetChars(buffer, 0, bytesRead);
                try
                {
                    tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length, Receive, null);
                }
                catch (Exception e)
                {
                    //something bad happened. Cleanup required
                }
            }
            else
            {
                //socket closed, I think?
                return;
            }
        }
