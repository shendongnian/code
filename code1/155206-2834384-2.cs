    public static bool RunWithTimeout(ThreadStart method, TimeSpan timeout, int maxTries) {
        while(maxTries > 0) {
            var thread = new Thread(method);
            thread.Start();
            if (thread.Join(timeout))
                return true;
            maxTries--;
        }
        return false;
    }
    if (!RunWithTimeout(
        delegate { xslTransform.Load(strXmlQueryTransformPath, xslSettings, new XmlUrlResolver()); },
        TimeSpan.FromSeconds(10),
        5  //tries
    ))
        //Error! Waaah!
