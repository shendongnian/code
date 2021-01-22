    public void Test()
        {
            string item = "item1";
            if (!SelectItem(listBox, item))
            {
                MessageBox.Show("Item not found.");
            }
        }
