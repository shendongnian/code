    private void subjectpagenextbtn_Click(object sender, EventArgs e)
    {
        TextBox[] subjectnamearray = new TextBox[] { subjectname1, subjectname2, subjectname3, subjectname4, subjectname5, subjectname6 };
        int i = 0;
        while (i <= numofsubjects.SelectedIndex)
        {
            if (subjectnamearray[i].Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill out all textboxes.", "Error Message");
                i = i + 1;
                return;
            }
        }
