        public string Title
        {
            get { return title; }
            set {
                if (value == "Hello")
                {
                    title = "ERROR";
                } else
                {
                    title = value;
                }
            }
        }
