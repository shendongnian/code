    namespace Samochody
    {
        public partial class Form1 : Form
        {
            // make sure your list looks like this, created outside your functions.
            List<Samochod> ListaSamochodow = new List<Samochod>();
            public Form1()
            {
                InitializeComponent();
                label1.Text = "the amount in your list is " + ListaSamochodow.Count.ToString();
                textBox1.Text = "string here";
                textBox2.Text = "string here";
                textBox3.Text = "100";
            }
    
                
            private void Form1_Load(object sender, EventArgs e)
            {
                XmlRootAttribute oRootAttr = new XmlRootAttribute();
                XmlSerializer oSerializer = new XmlSerializer(typeof(List<Samochod>), oRootAttr);
                StreamWriter oStreamWriter = null;
                oStreamWriter = new StreamWriter("samochody.xml");
                oSerializer.Serialize(oStreamWriter, ListaSamochodow);
            }
    
    
            private void button1_Click_1(object sender, EventArgs e)
            {
                Samochod s = new Samochod(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                ListaSamochodow.Add(s);
                label1.Text = "the amount in your list is " + ListaSamochodow.Count.ToString();
            }
        }
    }
