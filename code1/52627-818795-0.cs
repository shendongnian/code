    public class MyInputDialog : Form {
       public static string Execute(string Prompt) {
          using (var f = new MyInputDialog() ) {
             f.lblPrompt.Text = Prompt;
             f.ShowModal();
             return f.txtInput.Text;
          }
       }
    }
