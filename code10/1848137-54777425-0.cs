    private void Form1_Load(object sender, EventArgs e)
    {
        listView1.View = View.List;
        var items = new Dictionary<string, int>
        {
            {"Shaggy", 4},
            {"Fred", 6},
            {"Daphne", 10},
            {"Velma", 16},
            {"Scooby", 20},
        };
        foreach (var item in items)
        {
            int age = item.Value;
            Color foreColor;
            Color backColor;
            if (age <= 5)
            {
                foreColor = Color.Yellow;
                backColor = Color.Purple;
            }
            else if (age >= 6 && age <= 18)
            {
                foreColor = Color.Green;
                backColor = Color.BurlyWood;
            }
            else
            {
                foreColor = Color.Red;
                backColor = Color.CornflowerBlue;
            }
            listView1.Items.Add(new ListViewItem
            {Text = item.Key, ForeColor = foreColor, BackColor = backColor});
        }
    }
