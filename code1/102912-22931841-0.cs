    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBox textBox1 = new TextBox();
            textBox1.AutoCompleteCustomSource.AddRange(new string[] {
                "A",
                "A",
                "AA",
                "AAA"});
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.Controls.Add(textBox1);
        }
