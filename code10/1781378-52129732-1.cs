    public partial class Form2 : Form
    {
        Form1 Parent { get; }
        public Form2(Form1 parent)
        {
            Parent = parent;
            Parent.TextBoxValue = "SomeValue";
        }
    }
