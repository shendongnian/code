    comboBox1.Items.Clear();
    MyEnum[] e = (MyEnum[])(Enum.GetValues(typeof(MyEnum)));
    for (int i = 0; i < e.Length; i++)
    {
        comboBox1.Items.Add(e[i].ToString().Replace("_", " "));
    }
