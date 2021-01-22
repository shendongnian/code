    public static String toXmlString<T>(T value)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringWriter stringWriter = new StringWriter();
        try { xmlSerializer.Serialize(stringWriter, value); }
        catch (Exception e)
        {
            throw(e);
        }
        finally { stringWriter.Dispose(); }
        String xml = stringWriter.ToString();
        stringWriter.Dispose();
        return xml;
    }
    public static T fromXmlFile<T>(string fileName, Encoding encoding)
    {
        Stream stream;
        try { stream = File.OpenRead(fileName); }
        catch (Exception e)
        {
            
          e.Data.Add("File Name", fileName);
          e.Data.Add("Type", typeof(T).ToString());
          throw(e);
        }
    
        BufferedStream bufferedStream = new BufferedStream(stream);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
        TextReader textReader;
        if (encoding == null)
            textReader = new StreamReader(bufferedStream);
        else
            textReader = new StreamReader(bufferedStream, encoding);
    
        T value;
        try { value = (T)xmlSerializer.Deserialize(textReader); }
        catch (Exception e)
        {
            e.Data.Add("File Name", fileName);
            e.Data.Add("Type", typeof(T).ToString());
            throw(e);
        }
        finally
        {
            textReader.Dispose();
            bufferedStream.Dispose();
        }
        return value;
    }
