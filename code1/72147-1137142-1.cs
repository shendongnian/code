    public void Test()
        {
            string item = "item1";
            if (!SelectItem(listBox, item))
            {
                MessageBox.Show("It was not possible to select the item.");
            }
        }
