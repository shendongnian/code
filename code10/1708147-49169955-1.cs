    using System.Linq;
    public void pictureBox1_Click(object sender, EventArgs e)
    {
        string pizza0 = "Margheritta";
        ListViewItem pizza = new ListViewItem(pizza0);
        // get the number of pizzas in the listview that are named "Margheritta":
        int pizzaCount = 0;
        pizzaCount = listView1.Items.Where(x => x.Name == pizza0).Count();
        // or, if you can't use LINQ:
        foreach (var item in Items) {
            if (item.Name == pizza0)
                pizzaCount++;
        }
        pizza.SubItems.Add("x" + (pizzaCount + 1));
        listView1.Items.Add(pizza);
    }
