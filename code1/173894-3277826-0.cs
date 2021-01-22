    public class Test
        : MarkupExtension
    {
        public DependencyProperty Property { get; set; }
        public DependencyProperty Property2 { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Property ?? Property2;
        }
    }
