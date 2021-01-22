    Public boolAdd(String amount)
    
    {
    
    //Your Logic Like
    
    bool status = false;
    
    DbParam[] param = new DbParam[1];
    
    param[0] = new DbParam("@amount", "", "amount", SqlDbType.VarChar);
    
    status = Db.Update(ds, "sp_Add", "", "", param, true);
    
    return status;
    
      }
