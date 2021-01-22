    private static void Handler(object sender, ValidationEventArgs e)
    {
    
            if (e.Severity == XmlSeverityType.Error || e.Severity ==
    XmlSeverityType.Warning)
              System.Diagnostics.Trace.WriteLine(
                String.Format("Line: {0}, Position: {1} \"{2}\"",
                    e.Exception.LineNumber, e.Exception.LinePosition,
    e.Exception.Message));
    
    }
