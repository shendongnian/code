    /// <summary>
    /// asynchronous serializing of an object at the path specified by the FileInfo.
    /// </summary>
    /// <typeparam name="T">Type of the object to serialize</typeparam>
    /// <param name="fi">FileInfo to the target path</param>
    /// <param name="ObjectToSerialize">object to serialize</param>
    /// <param name="fileShare">File sharing mode during write</param>
    public static void SerializeXmlFile<T>(this FileInfo fi, T ObjectToSerialize, FileShare fileShare) //where T:IXmlSerializable
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        var TargetFile = fi.FullName;
        var fiTemp = new FileInfo(fi.FullName + ".tmp");
        int Stage = 0;
        try
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fiTemp.Open(FileMode.Create, FileAccess.Write, fileShare)))
                {
                    serializer.Serialize(writer, ObjectToSerialize);
                }
            }
            catch (Exception e)
            {
                throw new IOException("Unable to serialize to temp file, Error: " + e.Message, e);
            }
            Stage = 1;
            try
            {
                fiTemp.CopyTo(TargetFile, true);
                Stage = 2;
            }
            catch (Exception e)
            {
                throw new IOException("Unable to serialize to final file, Error replacing from temp: " + e.Message, e);
            }
            try
            {
                fiTemp.Delete();
            } catch (FileNotFoundException) { }
            catch (Exception e)
            {
                throw new IOException("Unable to cleanup temp file, Error: " + e.Message, e);
            }
            Stage = 3;
            
            fi.Refresh();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            switch (Stage)
            {
                case 1: // temp is written
                case 2: // temp is copied to destination, not yet deleted
                    {
                        try
                        {
                            fiTemp.Delete();
                        }
                        catch (FileNotFoundException) { }
                    }
                    break;
            }
        }
    }
