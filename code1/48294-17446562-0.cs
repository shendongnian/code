    string[] lbitems;
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox listBox = (ListBox)sender;
        if (listBox.SelectedItems.Count == 7)
        {
            for (int i = 0; i < listBox.SelectedItems.Count; i++)
            {
                bool trovato = false;
                for (int j = 0; j < lbitems.Length; j++)
                {
                    if (listBox.SelectedItems[i] == lbitems[j])
                    {
                        trovato = true;
                        break;
                    }
                }
                if (trovato == false)
                {
                    listBox.SelectedItems.Remove(listBox.SelectedItems[i]);
                    break;
                }
            }
        }
        else
        {
            lbitems = new string[listBox.SelectedItems.Count];
            listBox.SelectedItems.CopyTo(lbitems, 0);
        }
    }
