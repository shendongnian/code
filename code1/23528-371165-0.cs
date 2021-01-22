    protected event MessageListener progressMessageIntercepted;
    public void AddProgressMessageListener(MessageListener listener)
    {
        progressMessageIntercepted += listener;
    }
    public void RemoveMessageListeners()
    {
        progressMessageIntercepted = null;
    }
    protected void MessageCallBack(object sender, XsltMessageEncounteredEventArgs e)
    {
        if (e.Message.StartsWith("progress:"))
        {
            if (progressMessageIntercepted != null)
            {
                progressMessageIntercepted(this, null);
            }
        }
    }
    protected void Transform(string inputFile, string outputFile, string xsltFile)
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltFile);
        XsltArgumentList parameters = new XsltArgumentList();
        parameters.XsltMessageEncountered += new XsltMessageEncounteredEventHandler(MessageCallBack);
        using (XmlWriter xmlWriter = XmlWriter.Create(outputFile))
        {
            xslt.Transform(inputFile, parameters, xmlWriter);
        }
    }
