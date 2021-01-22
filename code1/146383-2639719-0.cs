    class OtherClass
    {
       public delegate void TextToBox(string s);
    
       TextToBox textToBox;
    
        Public OtherClass()
        {
        }
    
       public OtherClass(TextToBox ttb) 
       {
           textToBox = ttb;
       }
    
       public void SendSomeText(string foo)
       {
           var handler = this.TextToBox;
           if(handler != null)
           {
               textToBox(foo);
           }
       }
    }
