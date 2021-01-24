    public class UserInfo
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
    }
    var enumerableList = manager.Execute("** query **",
        (reader) =>
        {
            return new UserInfo()
            {
                FirstName = reader.Get<string>("FirstName"),
                LastName = reader.Get<string>("LastName "),
            };
        })
