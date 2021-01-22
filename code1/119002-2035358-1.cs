    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            propertyGrid1.SelectedObject = new Foo();
        }
    }
    public class Foo {
        [DefaultValue("foo")]
        public string MyString { get; set; }
        [DefaultValue(typeof(Color), "209 , 175, 171")]
        public Color MyColor { get; set; }
    }
