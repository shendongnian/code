    public string PlainTextDescription
    {
       get { 
           return this.Description.Replace(@"""","");
       }
    }
