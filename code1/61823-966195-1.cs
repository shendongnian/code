    //Interface to be able to which classes are able to give a boolean result used in the if stuff
    public interface IResultable
    {
        bool Result();
    }
    //A list that is IResultable itself it gathers the results of the IResultables inside.
    public class ComparatorList<T> : List<T>, IResultable where T : IResultable
    {
        public bool Result()
        {
            bool retval = true;
            foreach (T t in this)
            {
                if (!t.Result())
                {
                    retval = false;
                }
            }
            return retval;
        }
    }
    //Or two bools
    public class OrComparator : IResultable
    {
        bool left;
        bool right;
        public OrComparator(bool left, bool right)
        {
            this.left = left;
            this.right = right;
        }
        #region IResultable Members
        public bool Result()
        {
            return (left || right);
        }
        #endregion
    }
    // And two bools
    public class AndComparator : IResultable
    {
        bool left;
        bool right;
        public AndComparator(bool left, bool right)
        {
            this.left = left;
            this.right = right;
        }
        #region IResultable Members
        public bool Result()
        {
            return (left && right);
        }
        #endregion
    }
    // compare two ints
    public class IntIsComparator : IResultable
    {
        int left;
        int right;
        public IntIsComparator(int left, int right)
        {
            this.left = left;
            this.right = right;
        }
        #region IResultable Members
        public bool Result()
        {
            return (left == right);
        }
        #endregion
    }
