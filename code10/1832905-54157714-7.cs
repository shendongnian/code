    public class Friend : IComparable<Friend>
    {
        public Friend() { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FriendshipLevel { get; set; }
        int IComparable<Friend>.CompareTo(Friend other)
        {
            if (other.FriendshipLevel > this.FriendshipLevel) return -1;
            else return (other.FriendshipLevel == this.FriendshipLevel) ? 0 : 1;
        }
    }
    public class MyFriends : List<Friend>
    {
        public MyFriends() { }
        public int? GetID(string FriendName)
        {
            return this.Where(f => f.FirstName == FriendName).FirstOrDefault()?.ID;
        }
        public Friend GetFriendByID(int FriendID)
        {
            return this.Where(f => f.ID == FriendID).FirstOrDefault();
        }
    }
