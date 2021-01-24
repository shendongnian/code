    public void UpdateClaimSts(string[] ids) {  
      // :id_0, :id_1, ..., :id_N   
      string bindVariables = string.Join(", ", ids
        .Select((id, index) => $":id_{index}"));
     
      string query = $@"UPDATE MYTABLE
                           SET STATUS = 'X'
                         WHERE TABLEID IN ({bindVariables})";
     using (OracleCommand dbCommand = ...) {
       ...
       for (int i = 0; i < ids.Length; ++i)
         dbCommand.Parameters.Add($":id_{i}", OracleType.VarChar).Value = ids[i];
            
       ...
 
