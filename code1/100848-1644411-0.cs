    public class MyForm : Form
    {
        private PropertyGrid _grid = new PropertyGrid();
    
        public MyForm()
        {
            this._grid.BrowsableAttributes = new AttributeCollection(new UserEditableAttribute());
            this._grid.SelectedObject = new MyControl();
        }
    }
    
    public class UserEditableAttribute : Attribute
    {
    
    }
    
    public class MyControl : UserControl
    {
        private Label _label = new Label();
        private TextBox _textBox = new TextBox();
    
        [UserEditable]
        public string Label
        {
            get
            {
                return this._label.Text;
            }
            set
            {
                this._label.Text = value;
            }
        }
    
        [UserEditable]
        public string Value
        {
            get
            {
                return this._textBox.Text;
            }
            set
            {
                this._textBox.Text = value;
            }
        }
    }
