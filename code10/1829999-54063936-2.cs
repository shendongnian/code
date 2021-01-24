    public class AppViewModel : BaseBind
    {
        public AppViewModel()
        {
            // ...
        }
        // All common app data
        private string sampleCommonString;
        public String SampleCommonString
        {
            get { return sampleCommonString; }
            set { SetProperty(ref sampleCommonString, value); OnPropertyChanged(nameof(SampleDerivedProperty1)); OnPropertyChanged(nameof(SampleDerivedProperty2)); }
        }
        public String SampleDerivedProperty1 =>  "return something based on SampleCommonString";
        public String SampleDerivedProperty2
        {
            get
            {
                <<evaluate SampleCommonString>>
                return "Same thing as SampleDerivedProperty1, but more explicit";
            }
        }
        // This is a property that you can use for functions and internal logic… but it CAN'T be binded
        public String SampleNOTBindableProperty { get; set; }
        public void SampleFunction()
        {
            // Insert code here.
            // The function has to be with NO parameters, in order to work with simple {x:Bind} markup.
            // If your function has to access some specific data, you can create a new bindable (or non) property, just as the ones above, and memorize the data there.
        }
    }
