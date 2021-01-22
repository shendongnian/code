    class OtherClass
    {
       public delegate void TextToBox(string s);
    
       private readonly TextToBox textToBox;
    
       public OtherClass(TextToBox textToBox) 
       {
           if (textToBox == null)
               throw new ArgumentNullException("textToBox");
           this.textToBox = textToBox;
       }
    
       public void SendSomeText(string foo)
       {
           textToBox(foo);
       }
    }
