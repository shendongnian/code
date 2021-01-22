    public partial class Form1 : Form
        {
            Stack<Func<object>> undoStack = new Stack<Func<object>>(); 
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.U && Control.ModifierKeys == Keys.Control && undoStack.Count > 0)
                    undoStack.Pop()();                
            }
    
            private void textBox_KeyPress(object sender, KeyPressEventArgs e)
            {            
                if (!(e.KeyChar!= 'u' && Control.ModifierKeys == Keys.Control))
                {
                    var textBox = (TextBox)sender;
                    undoStack.Push(textBox.Text(textBox.Text));
                }
            }
        }
        public static class Extensions
        {
            public static Func<TextBox> Text(this TextBox textBox, string text)
            {            
                return () => { textBox.Text = text; return textBox; };
            }
        }
