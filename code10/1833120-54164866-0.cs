    class MyArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public MyArgumentOutOfRangeException(string myName):base("PlaceDefaultNamepropValue")
        {
            // do something with passed my name
        }
        public MyArgumentOutOfRangeException(string myname, string mymessage):base("PlaceDefaultNamepropValue", "PlaceDefaultMessagepropValue")
        {
            // do something with passed my name
            // do something with passed my message
        }
    }
    class MyOtherArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public MyOtherArgumentOutOfRangeException(string myName) : this("PlaceDefaultNamepropValue",string.Empty)
        {
            // do something with passed my name
        }
        public MyOtherArgumentOutOfRangeException(string myname, string mymessage) : base("PlaceDefaultNamepropValue", "PlaceDefaultMessagepropValue")
        {
            // do something with passed my name
            // do something with passed my message
        }
    }
