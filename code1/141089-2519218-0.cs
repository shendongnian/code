    class OtherClass
    {
        public delegate void TextToBox(string aString);
    
        TextToBox textToBox;
    
        public OtherClass(TextToBox ttb)
        {
            textToBox = ttb;
        }
    
        ...
    
        void SomeMethod()
        {
            textToBox("Hello!");
        }
    }
