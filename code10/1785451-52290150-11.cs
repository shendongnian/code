    public void UpdateClaimSts(string[] ids) {  
      // :id_0, :id_1, ..., :id_N   
      string bindVariables = string.Join(", ", ids
        .Select((id, index) => ":id_" + index.ToString()));
     
      string query = string.Format(
        @"UPDATE MYTABLE
             SET STATUS = 'X'
           WHERE TABLEID IN ({0})", bindVariables);
      // Do not forget to wrap IDisposable into "using"
      using (OracleCommand dbCommand = ...) {
        ...
        // Each item of the ids should be assigned to its bind variable
        for (int i = 0; i < ids.Length; ++i)
          dbCommand.Parameters.Add(":id_" + i.ToString(), OracleType.VarChar).Value = ids[i];
            
       ...
 
