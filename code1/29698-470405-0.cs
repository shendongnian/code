    public string TransformDocument(XmlDocument doc, XmlDocument stylesheet)
    {
       XslCompiledTransform transform = new XslCompiledTransform();
       transform.Load(stylesheet); // compiled stylesheet
       System.IO.StringWriter writer = new System.IO.StringWriter();
       transform.Transform(doc, writer);
       return writer.ToString();
    }
