     XmlDocument workingDocument = new XmlDocument();  
     workingDocument.LoadXml(sampleInfo); //sampleInfo comes in as a string.
     int SampleID = SampleID;  //the SampleID comes in as an int.   
     XmlNode currentNode;
     XmlNode parentNode;  
     // workingDocument.RemoveChild(workingDocument.DocumentElement.SelectSingleNode("/Tags/Tag/Sample[@ID=SampleID]"));
      if (workingDocument.DocumentElement.HasChildNodes)
       {                              
                               //This won't work:   currentNode = workingDocument.RemoveChild(workingDocument.SelectSingleNode("//Sample[@ID=" + SampleID + "]"));
                              currentNode = workingDocument.SelectSingleNode("Tags/Tag/Sample[@ID=" + SampleID + "]");
                              parentNode = currentNode.ParentNode;
                              if (currentNode != null)
                              {
                                  parentNode.RemoveChild(currentNode);
                              }                              
                 
                    // workingDocument.Save(sampleInfo);
    
                               sampleInfo = workingDocument.InnerXml.ToString();
    }
