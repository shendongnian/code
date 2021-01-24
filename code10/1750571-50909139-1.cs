    public partial class A : Form
    {
       private B secondForm;
       ...
       // event handler for button with text 'Show Form2'
       private void ShowNewForm(object sender, EventArgs e)
       {
          if (secondForm == null)
          {
             secondForm = new B();
          }
          secondForm.Show();
       }
       
       // event handler for button with text 'Change panel color'
       private void ChangePanelColor(object sender, EventArgs e)
       {
          secondForm.ChangePanelColor(Color.Black);
       }
    }
 
