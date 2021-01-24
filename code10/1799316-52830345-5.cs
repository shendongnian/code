    DialogResult current = DialogResult.No;
    do
    {
        key = CmboBox.SelectedItem.ToString();
        DialogResult dialogResult = MessageBox.Show("Select next key", "Continue?", MessageBoxButtons.YesNo);
        if (!keys.Contains(key))
        {
             if (n < keys.Length)
                  keys[n++] = key;
        }
        else
        {
            MessageBox.Show("You have already added this Key","Error");
        }
    }while(dialogResult == DialogResult.Yes);
