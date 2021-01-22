    public ArrayList Components
        {
            get { return new ArrayList { Reader, Filters, Router, Persister  }; } 
            set
            {
                ArrayList list = value;
                if(list != null)
                {
                    foreach (var item in list)
                    {
                        if(item is Reader)
                        {
                            Reader = (Reader)item;
                        }
                        else if(item is Router)
                        {
                            Router = (Router) item;
                        }
                        else if(item is Persister)
                        {
                            Persister = (Persister) item;
                        }
                        else if(item is Filters)
                        {
                            Filters = (Filters) item;
                        }
                    }
                }
            }
        }
