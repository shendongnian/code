    public class Friends
    {
        public string   ID      { get; set; }
        public string   Name    { get; set; }
        public string   Image   { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
            List <Friends> friendsList = new List<Friends>();
            
            foreach (var friend  in friendz)
            {
                friendsList.Add(
                    new Friends { ID = friend.id, Name = friend.name }    
                );
                
            }
    
            this.rptFriends.DataSource = friendsList;
            this.rptFriends.DataBind();
    }
