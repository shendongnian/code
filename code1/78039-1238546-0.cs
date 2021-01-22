    for (int count = 0; count < 10; count++)
        {
            ListItem li = new ListItem();
            li.Text = count.ToString();
            li.Value = count.ToString();
            if (count == 4 || count == 8)
            {
                li.Attributes.Add("style", "Color: Red");
            }
            lst.Items.Add(li);
        }
