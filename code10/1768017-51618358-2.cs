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
                    }
                };
            }
            catch (DirectoryNotFoundException dnf_ex)
            {
                throw;  //Log, store&notify. Your usual handling.
            }
            catch (PathTooLongException ptl_ex)
            {
                throw;  //Same
            }
            catch (IOException io_ex)
            {
                throw;  //Same
            }
        }
    };
    return ["YourFileName"];
