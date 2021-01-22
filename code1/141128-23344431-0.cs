    public Form1()
    {
        InitializeComponent();
        ...
        ByteViewer bv = new ByteViewer();
        bv.SetFile(@"c:\windows\notepad.exe"); // or SetBytes
        Controls.Add(bv);
    }
