public class GeoData
{
   public List<Country> GetCountries()
   {
      IDbConnection con = ConnectionFactory.GetConnection();
      //Sql stuff to return countries from a database
   }
}
