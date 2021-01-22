    using (FileStream fs = new FileStream(@"c:\svclog.txt", FileMode.OpenOrCreate, FileAccess.Write)
    {
        using (using (StreamWriter m_streamWriter = new StreamWriter(fs)))
        {
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine("Service Started on " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString());
            m_streamWriter.WriteLine(" *----------------*");
        }
    }
