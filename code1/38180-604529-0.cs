            public int age { 
            get
            {
                if (Request.QueryString["Age"] == null)
                    return 0;
                else
                    return int.Parse(Request.QueryString["Age"]);                                    
            }
        }
