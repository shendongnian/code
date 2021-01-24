    private void btnShow_Click(object sender, EventArgs e)
    {
        foreach (var item in _students)
        {
            lbStudents.Items.Add(item.Name + " | " + item.Age);
        }
    }
