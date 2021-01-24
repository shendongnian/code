    DialogResult current = DialogResult.No;
    do
    {
        key = CmboBox.SelectedItem.ToString();
        if (!keys.Contains(key))
        {
             if (n < keys.Length)
                  keys[n++] = key;
              DialogResult dialogResult = MessageBox.Show("Select next key", "Continue?", MessageBoxButtons.YesNo);
        }
        else
        {
            MessageBox.Show("You have already added this Key","Error");
        }
    }while(dialogResult == DialogResult.Yes);
