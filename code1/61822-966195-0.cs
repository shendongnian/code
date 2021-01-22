    public interface IResultable
    {
        bool Result();
    }
    public class ComparatorList<T> : List<T> where T : IResultable
    {
        public bool Result()
        {
            bool retval = true;
            foreach (T t in base)
            {
                if (!t.Result())
                {
                    retval = false;
                }
            }
            return retval;
        }
    }
    public class OrComparator : IResultable
    {
        int left;
        int right;
        public OrComparator(bool left, int right)
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
    public class IntIsComparator : IResultable
    {
        int left;
        bool right;
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
