    private void Method()
    {
        int k = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Controls.Add(new Button() { Top = 50 + (50 * i), Left = 50 + (50 * j), Width = 50, Height = 50, Text = (++k).ToString() });
            }
        }
        Controls.OfType<Button>().ToList().ForEach(x => x.Click += Button_Click);
    }
    private void Button_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show((sender as Button).Text);
    }
