    public List<Models.Details> SessionList
        {
            get
            {
                var obj = Session["myList"];
                if (obj == null) { obj = Session["myList"] = new List<Models.Details>(); }
                return (List<Models.Details>)obj;
            }
            set
            {
                Session["myList"] = value;
            }
        }
        public Guid guid;
