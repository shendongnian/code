    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load (object sender, EventArgs e) { }
        protected override void OnInit (EventArgs e) {
            base.OnInit(e);
            //if (!IsPostBack) {
                string listClientID = BulletedList1.ClientID.Replace('_', '$');
                int counter = 0;
                List<SomeClass> items = new List<SomeClass>(){ new SomeClass() { Rank = 1, Title = "2"},
                new SomeClass () {Rank = 2, Title = "Two"}};
                foreach (var item in items) {
                    // Add Button
                    ListItem listItem = new ListItem();
                    listItem.Value = "buttonItem" + item.Rank;
                    listItem.Text = " " + item.Title;
                    listItem.Attributes.Add("onclick", "__doPostBack('" + listClientID + "', '" + counter.ToString() + "')");
                    BulletedList1.Items.Add(listItem);
                    counter++;
                }
            //}
        }
        protected void MenuItem_Click (object sender, BulletedListEventArgs e) {
            Response.Write(e.Index);
        }
        class SomeClass {
            public int Rank;
            public string Title;
        }
    }
