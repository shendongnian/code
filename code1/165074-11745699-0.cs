    Dictionary<string, string>test = new Dictionary<string, string>();
            test.Add("1", "dfdfdf");
            test.Add("2", "dfdfdf");
            test.Add("3", "dfdfdf");
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
