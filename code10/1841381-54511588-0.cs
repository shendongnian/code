    namespace DisplayObjectsInForm
     {
    public partial class Form1 : Form
    {
        public Araba Araba1 = new Araba();
        public Araba Araba2 = new Araba();
        public Araba Araba3 = new Araba();
        public Araba DisplayingAraba;//Remove the initialization from here. 
        public Form1()
        {
            InitializeComponent();
            DisplayingAraba = new Araba(); //Add this line here
            Araba1.sName = "Araba1";
            Araba1.sColor = "Kirmizi";
            Araba1.nModel = 1999;
            Araba2.sName = "Araba2";
            Araba2.sColor = "Mavi";
            Araba2.nModel = 2005;
            Araba3.sName = "Araba3";
            Araba3.sColor = "Gri";
            Araba3.nModel = 2018;
      
