    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<MyClass> list = new List<MyClass>();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = typeof(WindowsFormsApplication1.MyClass);
            list.AddRange(new MyClass[] {
                new MyClass { Column1 = "1", Column2 = "1" },
                new MyClass { Column1 = "2", Column2 = "2" }
                });
            bindingSource1.DataSource = list;
            bindingSource1.Add(new MyClass { Column1 = "3", Column2 = "3" });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Here you remove rows without taking care of the representation:
            bindingSource1.RemoveAt(0); 
        }
    }
    class MyClass
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
