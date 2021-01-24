    private void AddOrMessage(RadioButton[] radioButtons)
    {
        for (int i = 0; i < radioButtons.Length; i++)
        {
            if (radioButtons[i].IsChecked == true)
            {
                all1 += $"{i + 1}";
                return;
            }
        }
        MessageBox.Show("An option is not selected");
    }
