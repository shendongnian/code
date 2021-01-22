    List<ListItem<MyEnum>> enumVals = new List<ListItem<MyEnum>>();
    
    foreach( MyEnum m in Enum.GetValues (typeof(MyEnum) )
    {
        enumVals.Add (new ListItem<MyEnum>(m, m.ToString());
    }
    
    myComboBox.DataSource = enumVals;
    myComboBox.ValueMember = "Key";
    myComboBox.DisplayMember = "Description";
