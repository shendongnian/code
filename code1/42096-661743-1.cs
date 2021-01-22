        protected void Page_Load(object sender, EventArgs e)
        {
            Item i1 = new Item();
            i1.ItemName = "name1";
            i1.ItemValue = "foo";
            Item i2 = new Item();
            i2.ItemName = "name2";
            i2.ItemValue = DateTime.Now;
            List<Item> list1 = new List<Item>();
            list1.Add(i1);
            list1.Add(i2);
            MyTable.DataSource = list1;
            MyTable.DataBind();
        }
