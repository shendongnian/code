    partial class MyUserInterface
    {
        public static MyUserInterface Instance { get; private set; }
        [...]
        public MyUserInterface()
        {
            InitializeComponent();
            Instance = this;
        }
    }
