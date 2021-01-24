            foreach(String string1 in Listbox1.Items)
            {
        foreach(String string2 in Listbox2.Items)
             {
              cat1 = string.Substring(0, string1.Length - 4);
              cat2 = string2.Substring(0, string2.Length - 4);
                if(cat1==cat2)
                {
                    Listbox1.Items.Remove(string1);
