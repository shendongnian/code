public class GeoData
{
   public List<Country> GetCountries()
   {
      using (IDbConnection con = ConnectionFactory.GetConnection())
      {
        //Sql stuff to return countries from a database
      }
   }
}
