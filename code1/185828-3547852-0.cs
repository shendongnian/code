        private string[] myProp;
        public string[] MyProp
        {
            get
            {
                if (myProp == null)
                {
                    myProp = new String[2];
                }
                return myProp;
            }
            set
            {
                myProp = value;
            }
        }
