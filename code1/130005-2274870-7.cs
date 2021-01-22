        public static class ToStringExpander
        {
           public static string MyToString (this Object x)
           {
              return x.ToString();
           }
           public static string MyToString (this mytype x)
           {
              return "This is the to string of mytype!";
           }
        }
