    public IEnumerable<AClass> YourMethod()
    {
        foreach (XElement header in headersXml.Root.Elements())
        {
            yield return (ParseHeader(header));                
        }
    }
