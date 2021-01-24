    MyOrderClass orderInstance = this;
    
    using(IDbConnection cnn = GetYourOpenConnectionFromThisMethod())
    {
         string query = " --- as above --- ";
         int result = cnn.Execute(query, orderInstance);
    
    }
