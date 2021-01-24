    private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = getItems(comboBox1.Text);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }
        public static List<ComboboxItem> getItems(string text)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            try
            {
                List<ComboboxItem> Ilist = new List<ComboboxItem>();
                var query =  from x in context.testComboBoxes where SqlMethods.Like(x.name, '%' + text +'%') select x;
                foreach (var q in query)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.ID = q.id;
                    item.Name = q.name;
                    Ilist.Add(item);
                }
                return Ilist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public class ComboboxItem
        {
            public object ID { get; set; }
            public string Name { get; set; }
        }
