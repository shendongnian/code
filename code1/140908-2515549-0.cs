    public class PersonHistoryItem : DateEntity,IComparable
    {
        ...
        public int CompareTo(object obj)
        {
            PersonHistoryItem phi = (PersonHistoryItem)obj;
            return this.StartDate.CompareTo(phi.StartDate);
        }
    }
