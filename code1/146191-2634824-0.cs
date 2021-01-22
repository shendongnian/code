    class OtherClass 
    { 
    	public delegate void TextToBox(string s); 
    
    	TextToBox textToBox; 
    
    	public OtherClass() 
    	{ 
    	} 
    	public OtherClass(TextToBox ttb)  // ***Problem***  
    	{ 
    		textToBox = ttb; 
    	} 
    
    	public void SendSomeText(string foo) 
    	{ 
    		if (textToBox != null) 
    			textToBox(foo); 
    	} 
    } 
