    class OneHundredFields
    {
            public int Field1;
            public int Field2;
            ...
            public int Field100;
    }
    OneHundredFields Instance=new OneHundredFields() // Variable 'Instance' consumes 100*sizeof(int) bytes of memory.
    class OneHundredProperties
    {
        public int Property1
        {
            get
            {
                return(1000);
            }
            set
            {
                // Empty.
            }
        }
        public int Property2
        {
            get
            {
                return(1000);
            }
            set
            {
                // Empty.
            }
        }
        ...
        public int Property100
        {
            get
            {
                return(1000);
            }
            set
            {
                // Empty.
            }
        }
    }
    OneHundredProperties Instance=new OneHundredProperties() // !!!!! Variable 'Instance' consumes 0 bytes of memory. (In fact a some bytes are consumed becasue every object contais some auxiliarity data, but size doesn't depend on number of properties).
