    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    namespace MyNamespace.DataLayer
    { 
    public class MyCustomObjectData : IMyCustomObjectData
    {
        public async Task<ICollection<MyCustomObject>> MyMethodAsync(Func<GridReader, ICollection<MyCustomObject>> handleFunction)
        {
            ICollection<MyCustomObject> returnItems = null;
            string sqlProcedureName = "dbo.uspMyCustomObjectSelectStuff";
            try
            {
                using (IDbConnection dbConnection = /* your code here */)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add(/* your code here */);
                    GridReader gr = await dbConnection.QueryMultipleAsync(sqlProcedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 120);
                    if (null != handleFunction)
                    {
                        returnItems = handleFunction(gr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return returnItems;
        }
    }
    }
