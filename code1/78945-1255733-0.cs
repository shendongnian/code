    public class MyOwnListViewItem : ListViewItem 
    {
        private UserData userData;
    
        public MyOwnListViewItem(UserData userData) 
        {
            this.userData = userData;
            Update();
        }
    
        public void Update() 
        { 
           this.SubItems.Clear(); 
           this.Text = userData.Name; //for first detailed column
    
           this.SubItems.Add(new ListViewSubItem(this, userData.Surname)); //for second can be more
        }
    }
