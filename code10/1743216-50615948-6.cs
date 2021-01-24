    public MainPage()
     {
         this.InitializeComponent();
         Item = new Info();
     }
    public Info Item { get; set; }
    <local:MyUseerControl Source="{x:Bind Item}"/>
