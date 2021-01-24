    static class Program
    {
      private static Form _form1;
      private static Form _form2;
      public static void Main()
      {
         _form1 = new MyForm();
         _form2 = new MyForm();
         _form1.MyTextbox.OnTextChanged += Form1_MyTextBox_TextChanged;
      }
      private void Form1_MyTextBox_TextChanged(object sender, EventArgs e)
      {
           _form2.MyTextBox.Text = _form1.MyTextbox.Text;
      }
      }
    }
    
    public class MyForm : Form 
    {
      public TextBox MyTextBox {get;set;}
    }
    
