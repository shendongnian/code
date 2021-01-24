    LinkedList<string> todoList = new LinkedList<string>();
    
    
     public void DisplayList()
        {
            ItemTextBox.Text = ""; //this is the very top box.
            ToDoListBox.Items.Clear();
    
            foreach(string MyString in todoList)
            {
                ToDoListBox.Items.Add(MyString);
            }
        }
    
        private void AddFrontButton_Click(object sender, EventArgs e)
        {
            System.Collections.IEnumerator iterator = todoList.GetEnumerator();
    
            //If the user desides to add the task to the front of the list.
           if(!String.IsNullOrWhiteSpace(ItemTextBox.Text))
            {
                todoList.AddFirst(ItemTextBox.Text);
                DisplayList();
            }
