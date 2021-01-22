    public void ShowWoho(object sender, EventArgs e)
    {
         MessageBox.Show("Woho");
    }
    ...
    button.Click += ShowWoho;
    ...
    button.Click -= ShowWoho;
