    using (Transaction t = cnctn.BeginTransation())
 
    `//set some options like timeout, use serialization level like //Serializable in .Net TransactionScope
    
       {
            string sql = "lock table MaxValueTable in exclusive mode";
            using (DbCommand cmd = cnctn.CreateCommand())
            { 
               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
              // execute command somehow!! 
            } 
           maxValue = GetMaxValue();
           SetMaxValue(maxValue + X);
           //I presume U need to update the value in the table so some Update would be nice
           sql = "lock table MaxValueTable in share mode";
           using (DbCommand cmd = cnctn.CreateCommand())
           { 
               cmd.CommandText = sql;
               cmd.ExecuteNonQuery();
               // execute command somehow!! 
           }
           cnctn.Commit();
      }
      catch(SQLException e)
      {
         //log whatever, gracefully handle things
         t.Rollback();
         //throw;?
      }
      finally
      {
            cntn.close();
      }
      
           
