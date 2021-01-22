    public class FormB : Form
    {
      public void Button1_Click(object sender, MouseEventArgs e)
      {
        formA.Label1Value = "FormB was clicked";
      }
    }
