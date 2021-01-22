    using Word;
            
    public void checkspelling(string text) 
    {
    	Word.Application app = new Word.Application();
    	object template=Missing.Value; 
            object newTemplate=Missing.Value; 
            object documentType=Missing.Value; 
            object visible=true; 
            object optional = Missing.Value; 
    
            _Document doc = app.Documents.Add(ref template, 
               ref newTemplate, ref documentType, ref visible);
    
            doc.Words.First.InsertBefore(text); 
            Word.ProofreadingErrors errors = doc.SpellingErrors; 
    
            ecount = errors.Count; 
            doc.CheckSpelling( ref optional, ref optional, ref optional, 
                ref optional, ref optional, ref optional, ref optional, 
                ref optional, ref optional, ref optional, ref optional, 
    	    ref optional);
    
            if (ecount == 0) 
            {
    		// no errors
    	}
            else
    	{
    		// errros
    	}
    }
