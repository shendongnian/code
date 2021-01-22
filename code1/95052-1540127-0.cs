    using System.ComponentModel;
    using System.Windows.Forms;
    [TypeConverter(typeof(ExpectationResultConverter))]
    public enum ExpectationResult
    {
        [Description("-")]
        NoExpectation,
    
        [Description("Passed")]
        Pass,
    
        [Description("FAILED")]
        Fail
    }
    
    class ExpectationResultConverter : EnumConverter
    {
        public ExpectationResultConverter()
            : base(
                typeof(ExpectationResult))
        { }
    
        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value,
            System.Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return "abc " + value.ToString(); // your code here
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    
    public class TestResult
    {
        public string TestDescription { get; set; }
        public ExpectationResult RequiredExpectationResult { get; set; }
        public ExpectationResult NonRequiredExpectationResult { get; set; }
    
        static void Main()
        {
            BindingList<TestResult> list = new BindingList<TestResult>();
            DataGridView grid = new DataGridView();
            grid.DataSource = list;
            Form form = new Form();
            grid.Dock = DockStyle.Fill;
            form.Controls.Add(grid);
            Application.Run(form);
        }
    }
