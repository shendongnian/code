        public string Title
        {
            get { return title; }
            set {
                if (value == "Hello")
                {
                    //value = "ERROR"; //--> this only changes the incoming value
                    title = "ERROR";   //--> this sets your backing field
                } else
                {
                    title = value;
                }
            }
        }
    }
