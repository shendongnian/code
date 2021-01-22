    class UnitWrapper {
        public int Unit {get;set;}
    }
    private UnitWrapper unit = new UnitWrapper();
    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.DataBindings.Add("Text", unit, "Unit");
    }
