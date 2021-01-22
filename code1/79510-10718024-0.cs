    protected object Deserialize(System.IO.StringReader reader)
    {
        var result = base.Deserialize(reader);
        CallBack(result);
        return result;
    }
    protected object Deserialize(System.IO.TextReader reader)
    {
        var result = base.Deserialize(reader);
        CallBack(result);
        return result;
    }
    protected object Deserialize(System.Xml.XmlReader reader)
    {
        var result = base.Deserialize(reader);
        CallBack(result);
        return result;
    }
    protected object Deserialize(System.IO.Stream stream)
    {
        var result = base.Deserialize(stream);
        CallBack(result);
        return result;
    }
    private void CallBack(object result)
    {
        var deserializedCallback = result as IXmlDeserializationCallback;
        if (deserializedCallback != null)
        {
            deserializedCallback.OnXmlDeserialization(this);
        }
    }
