    mylist.Add(new myclass   
    {      
         Field1 = rdr.IsDbNull(Field1_Ordinal)? 0: 
                   rdr.GetSqlInt32(Field1_Ordinal).Value,      
         Field2 = rdr.IsDbNull(Field2_Ordinal)? 0:  // whatever default value you wish...
                   rdr.GetSqlInt32(Field2_Ordinal).Value  // No error now
    });
