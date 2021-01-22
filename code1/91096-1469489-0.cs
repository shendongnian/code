    {
        SqlConnection sqlCon = new SqlConnection(strCon);
       //use sqlCon 
    }//scope ends
    //sqlCon  is not available after } 
    { //new scope starts
         SqlConnection sqlCon = new SqlConnection(strCon);
    }
