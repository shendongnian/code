    using (var outputFile = OpenOutput())
    using (XmlReader xml = OpenInput())
    {
       try
       {
           while (xml.ReadToFollowing("Category"))
           { 
               if (xml.IsStartElement())
               {
                   string name = xml.GetAttribute("BookName");
                  string price = xml.GetAttribute("BookPrice");
                  outputFile.WriteLine(string.Format("{0} {1}", name, price));
              }
          }
       }
       catch (XmlException xe)
       {
            // Parse error encountered. Would be possible to recover by checking
            // ReadState and continue, this would obviously require some 
            // restructuring of the code.
            // Catching parse errors is recommended because they could contain
            // sensitive information about the host environment that we don't
            // want to bubble up.
            throw new XmlException("Uh-oh");
       }       
    }
