    Public Form1()
    {
        InitializeComponent();
        cbxKeepWebInfinityChanges.DataBindings["Checked"].Parse += new ConvertEventHandler(cbxKeepWebInfinityChanges_Parse);
        cbxKeepWebInfinityChanges.DataBindings["Checked"].Format += new ConvertEventHandler(cbxKeepWebInfinityChanges_Format);
    }
    void cbxKeepWebInfinityChanges_Parse(object sender, ConvertEventArgs e)
    {
        if ((bool)e.Value == true)
            e.Value = "Yes";
        else
            e.Value = "No";
    }
    void cbxKeepWebInfinityChanges_Format(object sender, ConvertEventArgs e)
    {
        if ((string)e.Value == "Yes")
            e.Value = true;
        else
            e.Value = false;
    }
