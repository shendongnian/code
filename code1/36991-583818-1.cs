        public class Foo
        {
            public string Name;
        }
        public class Bar
        {
            public string ItemName { get; set; }
            public string ItemValue { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var fooKey1 = new Foo() {Name = "foo1"};
            var barList1 = new List<Bar>()
                   {
                       new Bar() {ItemName = "bar1", ItemValue = "barV1"},
                       new Bar() {ItemName = "bar2", ItemValue = "barV2"}
                   };
            var fooKey2 = new Foo() {Name = "foo2"};
            var barList2 = new List<Bar>()
                   {
                       new Bar() {ItemName = "bar3", ItemValue = "barV3"},
                       new Bar() {ItemName = "bar4", ItemValue = "barV4"}
                   };
            var dicFooBar = new Dictionary<Foo, List<Bar>>() {{fooKey1, barList1}, {fooKey2, barList2}};
            lvFooList.ItemDataBound += lvFooList_ItemDataBound;
            lvFooList.DataSource = dicFooBar;
            lvFooList.DataBind();
        }
        void lvFooList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var dataItem = (ListViewDataItem)e.Item;
            var fooBarList = (KeyValuePair<Foo, List<Bar>>)dataItem.DataItem;
            
            ((Label) dataItem.FindControl("lbName")).Text = fooBarList.Key.Name;
            var ddlListOfBars = (DropDownList) dataItem.FindControl("ddlListOfBars");
            ddlListOfBars.DataTextField = "ItemName";
            ddlListOfBars.DataValueField = "ItemValue";
            ddlListOfBars.DataSource = fooBarList.Value;
            ddlListOfBars.DataBind();
        }
