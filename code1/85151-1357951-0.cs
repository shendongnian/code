    using System.Windows.Forms;
    public class AutoCompleteTextBox : TextBox {
        private string[] database;//put here the strings of the candidates of autocomplete
        private bool changingText = false;
        
        protected override void OnTextChanged (EventArgs e) {
            if(!changingText && database != null) {
                //searching the first candidate
                string typed = this.Text.Substring(0,this.SelectionStart);
                string candidate = null;
                for(int i = 0; i < database.Length; i++)
                    if(database[i].Substring(0,this.SelectionStart) == typed) {
                        candidate = database[i].Substring(this.SelectionStart,database[i].Length);
                        break;
                    }
                if(candidate != null) {
                    changingText = true;
                    this.Text = typed+candidate;
                    this.SelectionStart = typed.Length;
                    this.SelectionLength = candidate.Length;
                }
            }
            else if(changingText)
                changingText = false;
            base.OnTextChanged(e);
        }
    }
