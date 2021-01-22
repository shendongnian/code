    public sealed class Program
        {
            public static void Main()
            {
                var user = new User
                               {
                                   Friends = new List<Int32>()
                               };
    
                if (user.Friends.Count() == 0)
                {
                    // TODO: Input logic here
                }
            }
        }
    
        /// <summary>
        /// User class
        /// </summary>
        public class User
        {
            /// <summary>
            /// Gets or sets the friends.
            /// </summary>
            /// <value>The friends.</value>
            public IEnumerable<Int32> Friends
            {
                get; set;
            }
        }
