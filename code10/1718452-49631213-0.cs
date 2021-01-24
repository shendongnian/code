      public RootTabLayout()
      {      
            InitializeComponent();
            // TABS \\
            myCuts = new MyCuts() // ContentPage
            {
                Icon = "cut.png",
                Title = "My Cuts",
            };
            newCut = new NewCut(RootCutCamera) // ContentPage
            {
                Icon = "camera.png",
                Title = "Creator"
            };
            myStyle = new MyStyle(UserDb, RootCutCamera) // ContentPage
            {
                Icon = "bowtie.png",
                Title = "My Style"
            };
            Children.Add(MyCuts);
            Children.Add(NewCut);
            Children.Add(MyStyle);
      }
