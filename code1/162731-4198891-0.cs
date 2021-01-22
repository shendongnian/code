    protected void btnTransfer_Click(object sender, EventArgs e)
    {
    	PdfReader reader = new PdfReader(FileUpload1.FileContent);
    	List<FileContent> lstAtt = GetAttachments(reader);
    	reader.Close(); 
    }
    
    private class FileContent
    {
    	public string Name { get; set; }
    
    	public byte[] Content { get; set; }
    }
    
    private List<FileContent> GetAttachments(PdfReader reader)
    {
    	#region Variables
    
    	PdfDictionary catalog = null;
    	PdfDictionary documentNames = null;
    	PdfDictionary embeddedFiles = null;
    	PdfDictionary fileArray = null;
    	PdfDictionary file = null;
    	
    	PRStream stream = null;
    
    	FileContent fContent = null;
    	List<FileContent> lstAtt = null;
    
    	#endregion
    
    	// Obtengo el conjunto de Diccionarios del PDF.
    	catalog = reader.Catalog;
    
    	// Variable que contiene la lista de archivos adjuntos.
    	lstAtt = new List<FileContent>();
    	
    	// Obtengo documento
    	documentNames = (PdfDictionary)PdfReader.GetPdfObject(catalog.Get(PdfName.NAMES));
    
    	if (documentNames != null)
    	{
    		// Obtengo diccionario de objetos embebidos
    		embeddedFiles = (PdfDictionary)PdfReader.GetPdfObject(documentNames.Get(PdfName.EMBEDDEDFILES));
    		if (embeddedFiles != null)
    		{
    			// Obtengo lista de documentos del Diccionario de objetos embebidos
    			PdfArray filespecs = embeddedFiles.GetAsArray(PdfName.NAMES);
    
    			// Cada archivo posee 2 posiciones en el array
    			for (int i = 0; i < filespecs.Size; i++)
    			{
    				// Como posee 2 posiciones por archivo, hago "i++"
    				i++;
    				fileArray = filespecs.GetAsDict(i);
    
    				// Obtengo diccionario del adjunto
    				file = fileArray.GetAsDict(PdfName.EF);
    
    				foreach (PdfName key in file.Keys)
    				{
    					stream = (PRStream)PdfReader.GetPdfObject(file.GetAsIndirectObject(key));
    
    					fContent = new FileContent();
    					// Nombre del Archivo.
    					fContent.Name = fileArray.GetAsString(key).ToString();
    					
    					// Array de bytes del Contenido del Archivo.
    					fContent.Content = PdfReader.GetStreamBytes(stream);
    					lstAtt.Add(fContent);
    				}
    			}
    		}
    	}
    
    	// Y al fin, devuelvo una lista de adjuntos del PDF - podrían haberlo echo un poco mas facil :@
    	return lstAtt;
    }
