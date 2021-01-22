        public PageView()
        {
            InitializeComponent();
            RadioButtonBinding rbWidth = new RadioButtonBinding(typeof(Library.EnumConstraint), this.pageBindingSource, "ConstraintWidth");
            rbWidth.AddControlsIntoGroupBox(this.groupBox1);
            RadioButtonBinding rbHeight = new RadioButtonBinding(typeof(Library.EnumConstraint), this.pageBindingSource, "ConstraintHeight");
            rbHeight.AddControlsIntoGroupBox(this.groupBox3);
            this.pageBindingSource.CurrentItemChanged += new EventHandler(pageBindingSource_CurrentItemChanged);
        }
