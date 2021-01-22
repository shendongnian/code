    public class Class1
    {
        public IList<Car> getCarsByProjectionOnSmallNumberOfProperties()
        {
            try
            {
                //Get the SQL Context:
                CompanyPossessionsDAL.POCOContext.CompanyPossessionsContext dbContext 
                    = new CompanyPossessionsDAL.POCOContext.CompanyPossessionsContext();
                //Specify the Context of your main entity e.g. Car:
                var oDBQuery = dbContext.Set<Car>();
                //Project on some of its fields, so the created select statment that is
                // sent to the database server, will have only the required fields By making a new anonymouse type
                var queryProjectedOnSmallSetOfProperties 
                    = from x in oDBQuery
                        select new
                        {
                            x.carNo,
                            x.eName,
                            x.aName
                        };
                //Convert the anonymouse type back to the main entity e.g. Car
                var queryConvertAnonymousToOriginal 
                    = from x in queryProjectedOnSmallSetOfProperties
                        select new Car
                        {
                            carNo = x.carNo,
                            eName = x.eName,
                            aName = x.aName
                        };
                //return the IList<Car> that is wanted
                var lst = queryConvertAnonymousToOriginal.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
