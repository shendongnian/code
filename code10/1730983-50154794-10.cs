        public CustomControl()
        {
            InitializeComponent();
            source.Add("Test");
            source.Add("TestItem");
            source.Add("TestValue");
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.AutoCompleteCustomSource = source;
        }
