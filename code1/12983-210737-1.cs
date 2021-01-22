    private void button1_Click(object sender, EventArgs e)
    {
      ClassA a1 = new ClassA() { PropertyA = "Tim" };
      ClassA a2 = new ClassA() { PropertyA = "Pip" };
      ClassB b1 = new ClassB() { PropertyB = "Alex" };
      ClassB b2 = new ClassB() { PropertyB = "Rachel" };
    
      List<MyBaseClass> list = new List<MyBaseClass>();
      list.Add(a1);
      list.Add(a2);
      list.Add(b1);
      list.Add(b2);
    
      foreach (var a in list.GetAllAs())
      {
        listBox1.Items.Add(a.PropertyA);
      }
    
      foreach (var b in list.GetAllbs())
      {
        listBox2.Items.Add(b.PropertyB);
      }
    }
