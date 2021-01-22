    void MyWritingMethod() {
        int sameAge = 35;
        {
            string name = "Joe";
            Log.Write(name + sameAge.ToString())
        }
        {
            string name = "Susan";
            Log.Write(name + sameAge.ToString())
        }
        // I'll never mix up Joe and Susan
    }
