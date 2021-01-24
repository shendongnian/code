    using System.Linq;
    public void pictureBox1_Click(object sender, EventArgs e)
    {
        string pizza0 = "Margheritta";
        ListViewItem pizza = new ListViewItem(pizza0);
        // get the number of pizzas in the listview that are named "Margheritta":
        var pizzaCount = listView1.Items.Where(x => x.Name == pizza0).Count();
        pizza.SubItems.Add("x" + (pizzaCount + 1));
        listView1.Items.Add(pizza);
    }
