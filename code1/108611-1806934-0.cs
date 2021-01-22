    public class MyForm1 : Form
    {
    
      public void ShowDialog2()
      {
        MyForm2 form2 = new MyForm2();
        form2.ShowDialog(this);
      }
    }
