    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    namespace TestLoadingMultiXml
    {
        public partial class Form1 : Form
        {
        private XmlMain xt;
        private string xname = @"x.xml";
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer x = new XmlSerializer(typeof(XmlMain));
            FileStream fs = new FileStream(xname, FileMode.Create);
            x.Serialize(fs, xt);
            fs.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            xt = new XmlMain();
            xname = Directory.GetCurrentDirectory() + @"\" + xname;
            if (File.Exists(xname))
            {
                XmlSerializer x = new XmlSerializer(typeof(XmlMain));
                FileStream fs = new FileStream(xname, FileMode.Open);
                xt = (XmlMain)x.Deserialize(fs);
                fs.Close();
            } // if (File.Exists(xname))
        }
    }
    }
