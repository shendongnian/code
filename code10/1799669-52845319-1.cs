    public void openForm2Button_Click(object sender, EventArgs e)
    {
        openForm2Button.BackColor = Color.Red;
        using (var form = new Classroom())
        {
            form.ShowDialog();
            // next line will be execute after form2 closed
            
            openForm2Button.Text = form.SelectedName; // update button text
        }
    }
