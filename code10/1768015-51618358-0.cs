    using (HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync())
    using (Stream ResponseStream = httpResponse.GetResponseStream())
    {
        if (httpResponse.StatusCode == HttpStatusCode.OK)
        {
            try
            {
                int buffersize = 132072;
                using (FileStream fileStream = File.Create(["YourFileName"], buffersize, FileOptions.Asynchronous))
                {
                    int read;
                    byte[] buffer = new byte[buffersize];
                    while ((read = await ResponseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, read);
                        resObject.ResourceLenght = fileStream.Position;
                    }
                };
            }
            catch (DirectoryNotFoundException dnf_ex)
            {
                throw;
            }
            catch (PathTooLongException ptl_ex)
            {
                throw;
            }
            catch (IOException io_ex)
            {
                throw;
            }
        }
    };
    return ["YourFileName"];
