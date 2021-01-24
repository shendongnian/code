    private byte[] CreatePDF(Rectangle pageSize, IList<IElement> elements, float marginLeft = 0f, float marginRight = 0f, float marginTop = 0f, float marginBottom = 0f)
    {
    	byte[] renderedBytes = null;
    				
    	using (MemoryStream ms = new MemoryStream())
    	{
    		// Margins: 72f = 1 inch
    		using (Document document = new Document(pageSize, marginLeft, marginRight, marginTop, marginBottom))
    		{
    			PdfWriter pdf = PdfWriter.GetInstance(document, ms);
    
    			document.Open();
    
    			foreach (IElement element in elements)
    			{
    				document.Add(element);
    			}
    
    			document.Close();
    
    			renderedBytes = ms.ToArray();
    
    			return renderedBytes;    
    		}
    	}
    }
