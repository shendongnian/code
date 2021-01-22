      var SaleItem = new
        {
            name = "Super Cereal",
            barcode = "0000222345",
            price = 2.55m
        };
        ListItem lt = new ListItem();
        string space = " ";
        lt.Text = String.Concat(SaleItem.name, 
            space, SaleItem.barcode, space, SaleItem.price);
        lt.Value = SaleItem.barcode;
        ListItem lt2 = new ListItem();
        lt2.Text = string.Copy(String.Format("{0}: {1} {2}", 
                   SaleItem.name, SaleItem.barcode, SaleItem.price.ToString("C")));
        lt2.Value = SaleItem.barcode;
        lstMailItems.Items.Add(lt);
        lstMailItems.Items.Add(lt2);
