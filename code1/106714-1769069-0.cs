     foreach (string flavourName in Enum.GetNames(typeof(Flavour)))
     {
         if (flavourName.StartsWith("APPLE"))
         {
             myComboBox.Items.Add(Enum.Parse(typeof(flavour), flavourName));
         }
     }
