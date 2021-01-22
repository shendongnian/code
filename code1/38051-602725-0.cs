    public DataTable ReturnSomething(){ 
       try {
            //logic here 
            return ds.Tables[0]; 
       } catch (Exception e) {
            ErrorString=e.Message;
            return null;
       }
    }
