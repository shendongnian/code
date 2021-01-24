    private List<Type> GetCode(string Left)
            {
                List<Type> List = new List<Type>();
    
                DbConnection();
                con.Open();
                DynamicParameters Parm = new DynamicParameters();
                Parm.Add("@Left", Left, DbType.String, ParameterDirection.Input, 2);
    //Parm.Add(nameOfParameter,valueOfParameter,typeOfParameter,directionOfParameter,sizeOfParameter);
                List = SqlMapper.Query<Type>(con, "Entities.GetCode", Parm, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return List;
            }
