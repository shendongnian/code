        /// <summary>
        /// Culture in which the GUI creates the control.
        /// </summary>
        private readonly CultureInfo _currentCulture;
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public MyControl()
        {
            InitializeComponent();
            _currentCulture = CultureInfo.CurrentUICulture;
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExampleClass.DoCultureDependentOperation(_currentCulture);
        }
