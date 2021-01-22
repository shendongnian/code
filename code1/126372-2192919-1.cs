    readonly Dictionary<string, string> values = new Dictionary<string, string>();
    public void AddBinding(TextBox box) {
        box.Change += TextBox_Change;
        values.Add(box.Name, box.Value);
    }
    void TextBox_Change(object sender, EventArgs e) {
        var box = (TextBox)sender;
        values[box.Name] = box.Value;
    }
    //Properties:
    public string Prop1 { get { return values["textBox1"]; } } 
    //Where textBox1 is the name of the textbox
