    internal class BaseUser
    {
        public static string DefaultUserPool { get; set; }
    }
    internal class User : BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Parent { get; set; }
    }
