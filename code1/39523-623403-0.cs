        private List<string> MyList = new List<string>();
        public string this[int i]
        {
            get
            {
                return MyList[i];
            }
            set
            {
                MyList[i] = value;
            }
            
        }
