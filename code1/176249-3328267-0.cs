    useofdelegates.Class1 ob;
    private void button1_Click(object sender, EventArgs e)
    {
      ob.fire();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      ob = new useofdelegates.Class1();
      ob.myevent+=new useofdelegates.Class1.mydelegate(ob_myevent);
    }
