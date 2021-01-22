        public Form1()
        {
            InitializeComponent();
            Binding binding = new Binding("Value", _car, "NumWheels", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown1.DataBindings.Add(binding);
            binding.BindingComplete += new BindingCompleteEventHandler(binding_BindingComplete);
            
        }
        void binding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception)
            {
                throw e.Exception;
            }
        }
