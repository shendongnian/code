             string[] Item = new string[] { TXTSearchItem.Text + "- " };
            if (Foods.ToLower().Contains(TXTSearchItem.Text.ToLower()))
            {
                string Substring = Foods.Split(Item, StringSplitOptions.None)[1];
                MessageBox.Show(Item[0] + "\n" + Substring);
            } 
