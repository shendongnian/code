       List<FileElements> lstFileElements = new List<FileElements>;
       foreach(string pdfFile in Directory.GetFiles(txtFolderPath.Text, "*.pdf",SearchOption.AllDirectories)
       {
          FileElements temp = New FileElements();
          temp.filename = Path.GetFileName(pdfFile);
          temp.extension = Path.GetExtension(pdfFile);
          //etc...
          lstFileElements.Add(temp);
       }
