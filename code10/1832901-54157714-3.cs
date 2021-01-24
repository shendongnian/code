    public class Friend
    {
        public Friend() { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte FriendshipLevel { get; set; }
    }
    public class MyFriends : List<Friend>, IComparable<Friend>
    {
        public MyFriends() { }
        public int? GetID(string FriendName) {
            return this.Where(f => f.FirstName == FriendName).FirstOrDefault()?.ID;
        }
        public Friend GetFriendByID(int FriendID) {
            return this.Where(f => f.ID == FriendID).FirstOrDefault();
        }
        int IComparable<Friend>.CompareTo(Friend other) {
            if (other.FriendshipLevel > this.Max(f => f.FriendshipLevel)) return -1;
            else return other.FriendshipLevel == this.Max(f => f.FriendshipLevel) ? 0 : 1;
        }
    }
