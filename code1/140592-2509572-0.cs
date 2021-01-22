    struct element : IComparable
    {
        double priority;
        int value;
        public element(int val, double prio)
        {
            priority = prio;
            value = val;
        }
        #region IComparable Members
        public int CompareTo(object obj)
        {
            // throws exception if type is wrong
            element other = (element)obj;
            return priority.CompareTo(other.priority);
        }
        #endregion
    }
