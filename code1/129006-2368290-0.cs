    public partial class Form1 : Form {
        public class Foo : List<Bar> {
            public string FooName { get; set; }
            public Foo(string name) { this.FooName = name; }
            public List<Bar> Items { get { return this; } }
        }
        public class Bar {
            public string BarName { get; set; }
            public string BarDesc { get; set; }
            public Bar(string name, string desc) {
                this.BarName = name;
                this.BarDesc = desc;
            }
        }
        public Form1() {
            InitializeComponent();
            List<Foo> foos = new List<Foo>();
            Foo a = new Foo("letters");
            a.Add(new Bar("a", "aaa"));
            a.Add(new Bar("b", "bbb"));
            foos.Add(a);
            Foo b = new Foo("digits");
            b.Add(new Bar("1", "111"));
            b.Add(new Bar("2", "222"));
            b.Add(new Bar("3", "333"));
            foos.Add(b);
            //Simple Related Object List Binding
            //http://blogs.msdn.com/bethmassi/archive/2007/04/21/simple-related-object-list-binding.aspx
            BindingSource comboBoxBindingSource = new BindingSource();
            BindingSource listBoxBindingSource = new BindingSource();
            comboBoxBindingSource.DataSource = foos;
            listBoxBindingSource.DataSource = comboBoxBindingSource;
            listBoxBindingSource.DataMember = "Items";
            comboBox1.DataSource = comboBoxBindingSource;
            comboBox1.DisplayMember = "FooName";
            listBox1.DataSource = listBoxBindingSource;
            listBox1.DisplayMember = "BarName";
            textBox1.DataBindings.Add("Text", listBoxBindingSource, "BarDesc");
        }
    }
