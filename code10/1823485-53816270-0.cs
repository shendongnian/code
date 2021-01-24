    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [Flags]
        public enum TestEnum : int
        {
            Name1 = 0,
            Name2 = 1,
            Name3 = 2
        } 
        public class TestObject
        {
            public string Name { get; set; } = "Hello World";
            public TestEnum[] TestProperty { get; set; } =
                new[] { TestEnum.Name1, TestEnum.Name2 | TestEnum.Name3, TestEnum.Name3 };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TestObject o = new TestObject();
            propertyGrid1.SelectedObject = o;
        }
    }
