     Dictionary<string, double> products = new Dictionary<string, double>()
            {
                {"Camping Chair",33.0},
                {"Stool",12.99},
            };
     //accessing the price via the key, which 
     var price = products.Where(x => x.Key == "Stool").SingleOrDefault();
     
     // you could then pass in the selected item of your list box as string
     var price = products.Where(x => x.Key == listbox.SelectedItem.ToString()).SingleOrDefault();
