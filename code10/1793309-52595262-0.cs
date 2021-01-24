    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SecondWindow newWin = new SecondWindow();
        newWin.Name = NameBox.Text; //Store value into SecondWindow variable
        newWin.Show();
        this.Close();
    }
