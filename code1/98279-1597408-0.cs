    class StringCollections{
        //A class is wrapping another collection
        string[] names=new string {“Jon Skeet”,”Hamish Smith”,
                                    ”Marc Gravell”,”Jrista”,”Joren”};
        public IEnumerator GetEnumerator() { return names.GetEnumerator(); }
    }
