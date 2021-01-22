    namespace WindowsFormsApplication7
    {
        [Serializable] // just put this in your class
        class Mate
        {
            public string SomeProperty { get; set; }
        }
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var mA = new Mate();
                mA.SomeProperty = "Hey";
                var vf = new BinaryFormatter();
                var ns = new MemoryStream();
                vf.Serialize(ns, mA);
                byte[] vytes = ns.ToArray();
                var vfx = new BinaryFormatter();
                var nsx = new MemoryStream();            
                nsx.Write(vytes, 0, vytes.Length);
                nsx.Seek(0, 0);
                var mB = (Mate)vfx.Deserialize(nsx);
                mA.SomeProperty = "Yo";
                MessageBox.Show(mA.SomeProperty); // Yo
                MessageBox.Show(mB.SomeProperty); // Hey
            }
        }
    }
    
