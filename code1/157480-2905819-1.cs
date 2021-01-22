     public string ApplyTransformation(string inputFilePath, string xsltFileContent)
        {
            XslCompiledTransform transform = new XslCompiledTransform(debugEnabled);
            
            File.WriteAllText(xsltTempFilePath,xsltFileContent);
            transform.Load(xsltTempFilePath, XsltSettings.TrustedXslt, new XmlUrlResolver());
            
            XmlReader reader = XmlReader.Create(inputFilePath);
            StringWriter output = new StringWriter();
            XmlWriter writer =  XmlWriter.Create(output,transform.OutputSettings);
            transform.Transform(reader,writer);
            return output.ToString();
        }
