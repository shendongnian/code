        //Example to define how to do :
    
        DataTable dt = new DataTable();   
    
        dt.Columns.Add("ID");
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("Address");
        dt.Columns.Add("City");
               //  The table structure is:
                //ID 	FirstName 	LastName 	Address 	City
    
           //Now we want to add a PhoneNo column after the LastName column. For this we use the                               
                 //SetOrdinal function, as iin:
            dt.Columns.Add("PhoneNo").SetOrdinal(3);
    
                //3 is the position number and positions start from 0.`enter code here`
    
                   //Now the table structure will be:
                  // ID 	 FirstName 	 LastName 	 LastName 	PhoneNo 	Address 	City
