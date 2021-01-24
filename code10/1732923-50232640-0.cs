    // Private member to hold the use created textboxes
    List<TextBox> textboxes = new List<TextBox>();
    // Sample code for your actual method where textboxes are added
    public void UserAddsTextBoxes(int userInput)
    {
        for (int index = 0; index < userInput; index++)
        {
            TextBox current = new TextBox();
            Controls.Add(current);
            // Also add it to our list for later
            textboxes.Add(current);
        }
    }
    public void OnSavingData()
    {
        textboxes.ForEach(x =>
        {
            MAcon.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into [Parts Inventroy]([Part ID],[Part Name],[Product Family ID] values(@PartID, @PartName, @ProductFamilyID)", MAcon);
            cmd.Parameters.AddWithValue("@ProductFamilyID", x.Text);
            cmd.ExecuteNonQuery();
            MAcon.Close();
        });
    }
 
