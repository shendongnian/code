    public Form1()
    {
        
        InitializeComponent();
        MyDataBase.AddField("jsmith/project1/hello.cs");
        MyDataBase.AddField("jsmith/project1/what.cs");
        MyDataBase.AddField("jsmith/project2/hello.cs");
        CreateTreeView();
    }
