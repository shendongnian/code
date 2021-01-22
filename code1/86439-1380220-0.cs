    //code when defining your button...
    {
         sqlButton.Tag = comboBoxA;  //instead of comboBoxA.Name
    }
    private void SQLButton(object sender, EventArgs e)
    {
        Button button = sender as Button;
        ComboBox comboBox = button.Tag as ComboBox;
        if (comboBox == null ) 
        {...}
        else
        {
            magic(comboBox);
        }
    }
    
    private void magic(ComboBox currentcombo)
    {
        string CurrentText = currentcombo.Text;
    }
