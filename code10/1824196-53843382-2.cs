    interface IPropertyHolder
    {
        string MyCustomProperty { get; }
    }
    class MyCustomControl1 : TextBox, IPropertyHolder
    {
        public string MyCustomProperty { get; set; }
    }
    class MyCustomControl2 : Form, IPropertyHolder
    {
        public string MyCustomProperty { get; set; }
    }
    class MyCustomControl3 : Control, IPropertyHolder
    {
        public string MyCustomProperty { get; set; }
    }
