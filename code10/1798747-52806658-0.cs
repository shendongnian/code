    public void ShowForm3()
    {
        this.Hide();
        using (Form3 f3 = new Form3())
        {
            f3.ShowDialog();
            this.Show();
        }
    }
