    public class User {
      IGetFromPresistance<User> _userFetcher;
      public static IList<User> GetMatching(Specification<User> spec) {
        var values = _userFetcher.Find(spec);  //Returns a DataRow or IDictionary<string, object>
        return new User() {
          PhoneNumber = new PhoneNumber(values["phone"].ToString()),
          Name = values["name"].ToString(),
        };
      }
    }
