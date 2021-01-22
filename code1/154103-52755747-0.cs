    public static async Task<string> GetRequestBody(HttpContext context)
        {
            string bodyText = string.Empty;
            try
            {
                var requestbody = context.Request.Body;
                context.Request.EnableRewind();
                int offset = 0, bytesread = 0;
                var buffer = new byte[5096];
                while ((bytesread = await context.Request.Body.ReadAsync(buffer, offset, buffer.Length - offset)) > 0)
                {
                    offset += bytesread;
                    if (offset == buffer.Length)
                    {
                        int nextByte = context.Request.Body.ReadByte();
                        if (nextByte == -1)
                        {
                            break;
                        }
                        byte[] newBuffer = new byte[buffer.Length * 2];
                        Array.Copy(buffer, newBuffer, buffer.Length);//how to avoid copy 
                        newBuffer[offset] = (byte)nextByte;//how to avoid boxing 
                        buffer = newBuffer;
                        offset++;
                    }
                    if (offset > 4194304)
                    {
                        //log.Warn("Middleware/GetRequestBody--> Request length exceeding limit");
                        break;
                    }
                }
                bodyText = Encoding.UTF8.GetString(buffer);
            }
            catch (Exception ex)
            {
                //log.Debug(ex, "Middleware/GetRequestBody--> Request length exceeding limit");
            }
            context.Request.Body.Position = 0;
            return bodyText;
        }
