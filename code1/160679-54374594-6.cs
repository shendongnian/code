     private void FlashNotify_Load(object sender, EventArgs e)
     { 
        // Deserialize from string back to object
        CommUserGroupMessage msg = new CommUserGroupMessage();
        msg = Newtonsoft.Json.JsonConvert.DeserializeObject<CommUserGroupMessage>(Json);
     }
