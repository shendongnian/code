    public class Users_Accounts
    {
        [Key]
        public int AccountID { get; set; }
        public Guid UniqueID { get; set; }
    
        //You can change the returned type of `Title` property from `Title` to `string` here
        public string Title { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
