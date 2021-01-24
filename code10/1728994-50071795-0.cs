    private void btnAdd_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        DateTime keyToAdd = dateTimePicker1.Value;
        if (tasks.ContainsKey(keyToAdd))
        {
            MessageBox.Show("Already exists, sorry ");
            return;
        }
        tasks.Add(keyToAdd, txtDescription.Text);
    }
