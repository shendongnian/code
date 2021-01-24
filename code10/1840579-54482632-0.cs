            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var list = new List<string>() {"Omg", "So Kewl", "I love it"};
            var collection = new AutoCompleteStringCollection();
            collection.AddRange(list.ToArray());
            comboBox1.AutoCompleteCustomSource = collection;
