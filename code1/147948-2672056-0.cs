    public class ThisClassIsFalse
    {
        public static bool operator true(ThisClassIsFalse statement)
        {
            return statement ? false : true;
        }
        public static bool operator false(ThisClassIsFalse statement)
        {
            return statement ? true : false;
        }
    }
