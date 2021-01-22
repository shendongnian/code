    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    
    [OracleCustomTypeMappingAttribute("MDSYS.SDO_ELEM_INFO_ARRAY")]
    public class NumberArrayFactory : IOracleArrayTypeFactory
    {
      public Array CreateArray(int numElems)
      {
        return new Decimal[numElems];
      }
    
      public Array CreateStatusArray(int numElems)
      {
        return null;
      }
    }
    
    private void Test()
    {
      OracleConnectionStringBuilder b = new OracleConnectionStringBuilder();
      b.UserID = "sna";
      b.Password = "sna";
      b.DataSource = "ora11";
      using (OracleConnection conn = new OracleConnection(b.ToString()))
      {
        conn.Open();
        using (OracleCommand comm = conn.CreateCommand())
        {
          comm.CommandText =
          @" select  /*+ cardinality(tab 10) */ c.*  " +
          @" from contract c, table(:1) tab " +
          @" where c.contractnum = tab.column_value";
    
          OracleParameter p = new OracleParameter();
          p.OracleDbType = OracleDbType.Array;
          p.Direction = ParameterDirection.Input;
          p.UdtTypeName = "MDSYS.SDO_ELEM_INFO_ARRAY";
          //select contract 3 and 4
          p.Value = new Decimal[] { 3, 4 };
          comm.Parameters.Add(p);
    
          int numContracts = 0;
          using (OracleDataReader reader = comm.ExecuteReader())
          {
            while (reader.Read())
            {
               numContracts++;
            }
          }
          conn.Close();
        }
      }
    }
