    string filePath = @"C:\Test\DocCopyTest.docm"; 
    
    using (WordprocessingDocument pkgDoc = WordprocessingDocument.Open(filePath, true))
    {
        //Gets only the file name, not path; included for info purposes, only
        DocumentFormat.OpenXml.ExtendedProperties.Template t = pkgDoc.ExtendedFilePropertiesPart.Properties.Template;
        string tName = t.Text;
        this.txtMessages.Text = tName;
        
        //The attached template information is stored in the DocumentSettings part
        //as a link to an external resource. So the information is not directly in the XML
       //it's part of the "rels", meaning it has to be accessed indirectly
        MainDocumentPart partMainDoc = pkgDoc.MainDocumentPart;
        ExternalRelationship r = null;
        string exRel_Id = "";
        string exRelType = "";
       //the file location of the new template, as a URI
        Uri rUri = new Uri("file:////C:/Test/DocCopy_Test2.dotm");
        Array exRels = partMainDoc.DocumentSettingsPart.ExternalRelationships.ToArray();
        foreach (ExternalRelationship exRel in exRels)
            if (exRel.RelationshipType.Contains("attachedTemplate"))
            {
                exRel_Id = exRel.Id;
                exRelType = exRel.RelationshipType;
                System.Diagnostics.Debug.Print(exRel_Id + " " + exRelType);
                partMainDoc.DocumentSettingsPart.DeleteExternalRelationship(exRel);
                r = partMainDoc.DocumentSettingsPart.AddExternalRelationship(exRelType, rUri, exRel_Id);
                System.Diagnostics.Debug.Print(r.Uri.ToString());
                break;
            }
    }
