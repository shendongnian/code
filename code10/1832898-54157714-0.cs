    public class Friend
    {
        public Friend() { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte FriendshipLevel { get; set; }
    }
    public class MyFriends : List<Friend>
    {
        public MyFriends() { }
        public int? GetID(string FriendName) {
            return this.Where(f => f.FirstName == FriendName).FirstOrDefault()?.ID;
        }
        public Friend GetFriendByID(int FriendID) {
            return this.Where(f => f.ID == FriendID).FirstOrDefault();
        }
    }
