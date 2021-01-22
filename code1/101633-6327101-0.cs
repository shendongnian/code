            var g = this.dataGridView1;
            var s = new Dictionary<string, string>();
            s.Add("1", "Test1");
            s.Add("2", "Test2");
            s.Add("3", "Test3");
            g.DataSource = s.ToArray();
