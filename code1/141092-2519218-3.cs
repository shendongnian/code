    /* this runs (previous code was not guaranteed to run) */
    class OtherClass
    {
        public delegate void TextToBox(string s);
        TextToBox textToBox;
        int next = 0;
        public OtherClass(TextToBox ttb)
        {
            textToBox = ttb;
        }
        public void SendSomeText()
        {
            textToBox(next.ToString());
            next++;
        }
    }
