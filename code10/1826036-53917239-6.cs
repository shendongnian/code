    namespace WindowsFormsApplication47
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var dataFromDb = GetData();
                foreach (var itm in dataFromDb)
                {
                    flowLayoutPanel1.Controls.Add(GetGroupBox(itm, 200, 100));
                }
            }
    
            private GroupBox GetGroupBox(Category c,int width,int height)
            {
                GroupBox g = new GroupBox();
                g.Size = new Size(width, height);
                g.Text = c.Name;
    
                var y = 20;
                foreach (var itm in c.Items)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = itm;
                    cb.Location = new Point(5, y);
                    // you can add an event here...
                    cb.CheckedChanged += cb_SomeEvent;
                    g.Controls.Add(cb);
                    y += 20;
                }
    
                return g;
            }
    
            private void cb_SomeEvent(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
    
            private List<Category> GetData()
            {
                // Just to simulate a database...
                Category c1 = new Category("Fruit", new List<string>() { "Banana", "Apple" });
                Category c2 = new Category("Vegetables", new List<string>() { "Avocado", "Tomato" });
                Category c3 = new Category("Programming Languages", new List<string>() { "C#", "Visual Basic" });
                Category c4 = new Category("Stars", new List<string>() { "Venus", "Mars" });
    
                List<Category> result = new List<Category>();
                result.Add(c1);
                result.Add(c2);
                result.Add(c3);
                result.Add(c4);
    
                return result;
            }
        }
    
        class Category
        {
            public string Name;
            public List<string> Items;
            public Category(string name,List<string> items)
            {
                this.Name = name;
                this.Items = items;
            }
        }
    }
