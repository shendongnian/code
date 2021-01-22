    public class Data
    {
        public static MyDBEntities MyDBEntities
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current["myDBEntities"] == null)
                {
                    HttpContext.Current["myDBEntities"] = new MyDBEntities ();
                }
                return HttpContext.Current["myDBEntities"] as MyDBEntities;
            }
            set { 
                if(HttpContext.Current != null)
                    HttpContext.Current["myDBEntities"] = value; 
            }
        }
    }
