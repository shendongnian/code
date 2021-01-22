    public static byte[] ReadFileBytes(string filePath)
    {
        byte[] buffer = null;
        try
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read
    
                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
    
                fileStream.Close(); //This is not needed, just me being paranoid and explicitly releasing resources ASAP
            }
        }
        catch (IOException ex)
        {
            //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
            if (IsFileLocked(ex))
            {
                // do something? 
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
        return buffer;
    }
    
    public static string ReadFileTextWithEncoding(string filePath)
    {
        string fileContents = string.Empty;
        byte[] buffer;
        try
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read
    
                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;  // sum is a buffer offset for next reading
                }
    
                fileStream.Close(); //Again - this is not needed, just me being paranoid and explicitly releasing resources ASAP
    
                //Depending on the encoding you wish to use - I'll leave that up to you
                fileContents = System.Text.Encoding.Default.GetString(buffer);
            }
        }
        catch (IOException ex)
        {
            //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
            if (IsFileLocked(ex))
            {
                // do something? 
            }
        }
        catch (Exception ex)
        {
        }
        finally
        { }     
        return fileContents;
    }
    
    public static string ReadFileTextNoEncoding(string filePath)
    {
        string fileContents = string.Empty;
        byte[] buffer;
        try
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read
    
                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0) 
                {
                    sum += count;  // sum is a buffer offset for next reading
                }
    
                fileStream.Close(); //Again - this is not needed, just me being paranoid and explicitly releasing resources ASAP
    
                char[] chars = new char[buffer.Length / sizeof(char) + 1];
                System.Buffer.BlockCopy(buffer, 0, chars, 0, buffer.Length);
                fileContents = new string(chars);
            }
        }
        catch (IOException ex)
        {
            //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
            if (IsFileLocked(ex))
            {
                // do something? 
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    
        return fileContents;
    }
