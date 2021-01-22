    public partial class MyForm: Form
    {
       .
       .
       .
       public void ShowMyFont()
       {
          Graphics graphics = this.CreateGraphics();
          graphics.DrawString("Hello world!", new Font("Arial", 12), Brushes.Black, 0, 0);
       }
    }
