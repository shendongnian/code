    public class MyClass
    {
        private ListView listView;
        public MyClass(ListView lv)
        {
            listView = lv;
        }
        public void add(string make, string model, string color, string miles, string condition, string interior, string highway, string city, string price)
        {
            string[] row = { make, model, color, miles, condition, interior, highway, city, price }; //adding rows to list
            ListViewItem item = new ListViewItem(row);
            listView.Items.Add(item);
        }
        // Delete method goes here
        // Move method goes here
    }
