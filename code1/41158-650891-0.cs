    public class SalesMan
    {
        public SalesMan(User user)
        {
            // Your logic to create a new SalesMan using data from user.
        }
        public static explicit operator SalesMan(User user)
        {
            return new SalesMan(user);
        }
    }
