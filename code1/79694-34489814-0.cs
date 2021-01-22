    void arsDigitTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        bool handle = regex.IsMatch(this.Text);
        if (handle)
        {
            StringBuilder dd = new StringBuilder();
            int i = -1;
            int cursor = -1;
            foreach (char item in this.Text)
            {
                i++;
                if (char.IsDigit(item))
                    dd.Append(item);
                else if(cursor == -1)
                    cursor = i;
            }
            this.Text = dd.ToString();
    
            if (i == -1)
                this.SelectionStart = this.Text.Length;
            else
                this.SelectionStart = cursor;
        }
    }
