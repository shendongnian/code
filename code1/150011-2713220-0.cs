            StringBuilder sb = new StringBuilder();           
            using (StreamReader reader = new StreamReader(streamRemote))
            {
                char[] charBuffer = new char[bufferSize];
                int charsRead;
                while ((charsRead = reader.Read(charBuffer, 0, bufferSize)) > 0)
                {
                    sb.Append(charBuffer, 0, charsRead);
                    //Some progress calculation
                    if (Progress != null) Progress(iProgressPercentage);
                }
            }
            string result = sb.ToString();
