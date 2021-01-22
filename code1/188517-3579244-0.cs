            ComboBox cb = new ComboBox();
            cb.Items.Add(new { fullname = "Company" + " " + "First Name" + " " + "Last Name", custId = 44 });
            cb.SelectedIndex = 0;
            var item = cb.SelectedItem;
            var custId = item.GetType().GetProperty("custId").GetValue(item, System.Reflection.BindingFlags.GetProperty, null, null, null);
