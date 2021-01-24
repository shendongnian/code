    //static WebMethod to serve ajax() call
        [WebMethod()]
        public static person GetData(string name)
        {
            person p= new person();
            p.name = name;
            return p;
        }
    }
