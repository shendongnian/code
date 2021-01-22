    public static int SaveColumnHeaderSet(ColumnHeaderSet set)
          //save a ColumnHeaderSet
          {       
             string sp = ColumnSP.usp_ColumnSet_C.ToString();    //name of sp we're using
             SqlCommand cmd = null;
             SqlTransaction trans = null;
             SqlConnection conn = null;
    
             try
             {
                conn = SavedRptDAL.GetSavedRptConn();  //get conn for the app's connString
                cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;   // Includes this cmd as part of the trans
    
                //parameters
                cmd.Parameters.AddWithValue("@ColSetName", set.ColSetName);
                cmd.Parameters.AddWithValue("@DefaultSet", 0);
                cmd.Parameters.AddWithValue("@ID_Author", set.Author.UserID);   
                cmd.Parameters.AddWithValue("@IsAnonymous", set.IsAnonymous);         
                cmd.Parameters.AddWithValue("@ClientNum", set.Author.ClientNum);
                cmd.Parameters.AddWithValue("@ShareLevel", set.ShareLevel);
                cmd.Parameters.AddWithValue("@ID_Type", set.Type);
    
                //add output parameter - to return new record identity
                SqlParameter prm = new SqlParameter();
                prm.ParameterName = "@ID_ColSet";
                prm.SqlDbType = SqlDbType.Int;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);
    
                cmd.ExecuteNonQuery();
                int i = Int32.Parse(cmd.Parameters["@ID_ColSet"].Value.ToString());
                if (i == 0) throw new Exception("Failed to save ColumnHeaderSet");
                set.ColSetID = i; //update the object
    
                //save the ColumnHeaderList (SetDetail)
                if (ColumnHeader_Data.SaveColumnHeaderList(set, conn, trans)==false) throw new Exception("Failed to save ColumnHeaderList");
                trans.Commit();
    
                // return ID for new ColHdrSet
                return i;
             }
             catch (Exception e){
                trans.Rollback();
                throw e;
             }
             finally{
                conn.Close();
             }
          }
    
     public static bool SaveColumnHeaderList(ColumnHeaderSet set, SqlConnection conn, SqlTransaction trans)
          //save a (custom)ColHeaderList for a Named ColumnHeaderSet
          {
             // we're going to accept a SqlTransaction to maintain transactional integrity
             string sp = ColumnSP.usp_ColumnList_C.ToString();    //name of sp we're using 
             SqlCommand cmd = null;
             try
             {
                cmd = new SqlCommand(sp, conn);     // re-using the same conection object
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;            // includes the cmd in the transaction
    
                //build params collection (input)
                cmd.Parameters.Add("@ID_ColSet", SqlDbType.Int);
                cmd.Parameters.Add("@ID_ColHeader", SqlDbType.Int);
                cmd.Parameters.Add("@Selected", SqlDbType.Bit);
                cmd.Parameters.Add("@Position", SqlDbType.Int);
    
                //add output parameter - to return new record identity
                //FYI - @return_value = @ID_SavedRpt
                SqlParameter prm = new SqlParameter();
                prm.ParameterName = "@ID";
                prm.SqlDbType = SqlDbType.Int;
                prm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prm);
    
                //Loop
                foreach (ColumnHeader item in set.ColHeaderList)
                {
                   //set param values
                   cmd.Parameters["@ID_ColSet"].Value = set.ColSetID; 
                   cmd.Parameters["@ID_ColHeader"].Value = item.ColHeaderID; 
                   cmd.Parameters["@Selected"].Value = item.Selected;
                   cmd.Parameters["@Position"].Value = item.Position;
    
                   cmd.ExecuteNonQuery();
                   int i = Int32.Parse(cmd.Parameters["@ID"].Value.ToString());
                   if (i == 0) throw new Exception("Failed to save ColumnHeaderSet");
                } 
                return true;
             }
             catch (Exception e)
             {
                throw e;            
             }
    
          }
