    public partial class Form1 : Form
    {
        Stack<Func<object>> undoStack = new Stack<Func<object>>();
        Stack<Func<object>> redoStack = new Stack<Func<object>>();
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown += TextBox1_KeyDown;
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && ModifierKeys == Keys.Control) { }
            else if (e.KeyCode == Keys.U && ModifierKeys == Keys.Control)
            {
                if(undoStack.Count > 0)
                {
                    StackPush(sender, redoStack);
                    undoStack.Pop()();
                }
            }
            else if (e.KeyCode == Keys.R && ModifierKeys == Keys.Control)
            {
                if(redoStack.Count > 0)
                {
                    StackPush(sender, undoStack);
                    redoStack.Pop()();
                }
            }
            else
            {
                redoStack.Clear();
                StackPush(sender, undoStack);
            }
        }
        private void StackPush(object sender, Stack<Func<object>> stack)
        {
            TextBox textBox = (TextBox)sender;
            var tBT = textBox.Text(textBox.Text, textBox.SelectionStart);
            stack.Push(tBT);
        }
    }
    public static class Extensions
    {
        public static Func<TextBox> Text(this TextBox textBox, string text, int sel)
        {
            return () => 
            {
                textBox.Text = text;
                textBox.SelectionStart = sel;
                return textBox;
            };
        }
    }
