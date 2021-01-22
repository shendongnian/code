    class NegateBinding
    {
        string propertyName;
        object dataSource;
        string dataMember;
        public NegateBinding(string propertyName, object dataSource, string dataMember)
        {
            this.propertyName = propertyName;
            this.dataSource = dataSource;
            this.dataMember = dataMember;
        }
        public static implicit operator Binding(NegateBinding eb)
        {
            var binding = new Binding(eb.propertyName, eb.dataSource, eb.dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += new ConvertEventHandler(negate);
            binding.Format += new ConvertEventHandler(negate);
            return binding;
        }
        static void negate(object sender, ConvertEventArgs e)
        {
            e.Value = !((bool)e.Value);
        }
    }
