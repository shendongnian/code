    public static Decimal ExecuteScalarDec(string procName, params object[] parameters)
      {
                 try
                 {
                          using(Database database = DatabaseFactory.CreateDatabase())
                          {
                            return (Decimal)database.ExecuteScalar(procName, parameters);
                          }
                 }
                    catch (Exception ex)
                {
                            throw new Exception(procName.ToString() + " " + parameters.ToString(), ex);
              }
        }
