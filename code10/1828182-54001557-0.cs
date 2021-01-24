    private List<OuterClass> OuterClassList { get; set; }//initialize in constructor.
    internal class OuterClass
    {
        public InnerClass InnerObject { get; set; }
    
        public OuterClass(int num) => InnerObject = new InnerClass(num);
    }
    
    internal class InnerClass
    {
        public int Value { get; set; }
        public InnerClass(int num) => Value = num;
    }
    
    private void button1_Click(object sender, EventArgs e) => OuterClassList.Add(new OuterClass(new Random().Next(0, 1000)));
    
    private void button4_Click(object sender, EventArgs e)
    {
        var values = from o in OuterClassList select o.InnerObject.Value;//you always have it, then you don't need InnerClassList I think.
        foreach (var value in values)
            MessageBox.Show(value.ToString());
    }
