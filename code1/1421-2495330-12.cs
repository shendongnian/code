    void MyWritingMethod() {
        int sameAge = 35;
        
        { // scope some work
            string name = "Joe";
            Log.Write(name + sameAge.ToString());
        }
        { // scope some other work
            string name = "Susan";
            Log.Write(name + sameAge.ToString());
        }
        // I'll never mix up Joe and Susan again
    }
