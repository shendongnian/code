    namespace Emailing
    {
        public partial class Form1 : Form
        {
        private XmlController xc;
        public Form1()
        {
            InitializeComponent();
            xc = new XmlController();
            xc.readXml(); //reads the xml when starts
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xc.updateXml(); //updates the xmls when the users clicks a button
        }
    }
