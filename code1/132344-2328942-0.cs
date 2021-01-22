    public class TaskComparer : IEqualityComparer<Task>
    {
        #region IEqualityComparer<Task> Members
        public bool Equals(Task x, Task y)
        {
            return x.TypeID == y.TypeID && x.TypeName == y.TypeName;
        }
        public int GetHashCode(Task obj)
        {
            return obj.TypeID.GetHashCode() + obj.TypeName.GetHashCode();
        }
        #endregion
    }
