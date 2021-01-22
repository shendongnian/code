        private string ReadData(TcpClient s, Func<string,bool> predicate)
        {
            // Reads a byte steam into a string builder until either data is unavailable or the terminator has not been reached
            var sb = new StringBuilder();
            do
            {
                var numBytesRead = s.GetStream().Read(byteBuff, 0, byteBuff.Length);
                sb.AppendFormat("{0}", Encoding.ASCII.GetString(byteBuff, 0, numBytesRead));
            } while (s.GetStream().DataAvailable && !predicate(sb));
            
            return sb.ToString();
        }
