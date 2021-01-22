     public partial class CustomControl : UserControl
        {
            public DependencyProperty FieldValueProperty { get; set; }
    
            public CustomControlViewModel Context = new CustomControlViewModel();
    
            public int FieldValue
            {
                get { return (int) GetValue(FieldValueProperty); }
                set
                {
                    SetValue(FieldValueProperty,value);
                }
            }
    
            public CustomControl()
            {
                this.DataContext = Context;
                FieldValueProperty = DependencyProperty.Register("FieldValue", typeof (int), typeof (CustomControl),
                                                                 new PropertyMetadata(FieldValueChanged));
                InitializeComponent();
                
            }
    
            void FieldValueChanged(Object sender, DependencyPropertyChangedEventArgs e)
            {
                Context.FieldValue = (int)e.NewValue;
            }
        }
    
        public class CustomControlViewModel : BaseClass
        {
            private int _fieldValue;
    
            public int FieldValue
            {
                get { return _fieldValue; }
                set
            { 
                _fieldValue = value;
                RaisePropertyChanged("FieldValue");
            }
            }
        }
