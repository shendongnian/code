    public sealed class GramTextBox : TextBox
    {
        //Constructor
        public GramTextBox() : base()
        {
            Text = "0g"; //Initial value
            TextChanged += OnTextChanged;
            DataObject.AddPastingHandler(this, OnPaste);
        }
        //Style override (get the Style of a TextBox for the GramTextBox)
        static GramTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GramTextBox), new FrameworkPropertyMetadata(typeof(TextBox)));
        }
        //Define a DependencyProperty to make it bindable (dont forget 'Mode=TwoWay' due the bound value is updated from this GramTextBox)
        [Category("Common"), Description("Converted double value from the entered Text in gram")]
        [Browsable(true)]
        [Bindable(true)]
        public double Gram
        {
            get { return (double)GetValue(PathDataProperty); }
            set { SetCurrentValue(PathDataProperty, value); }
        }
        public static DependencyProperty PathDataProperty = DependencyProperty.Register("Gram", typeof(double), typeof(GramTextBox), new PropertyMetadata(0d));
        //Extract the Gram value when Text has changed
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ExtractGram(Text);
        }
        //Suppress space input
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
        //Check text inputs
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !IsValidText(Text.Insert(CaretIndex, e.Text));
        }
        //check paste inputs
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            //Check if pasted object is string
            if(e.SourceDataObject.GetData(typeof(string)) is string text)
            {
                //Check if combined string is valid
               if(!IsValidText(Text.Insert(CaretIndex, text))) { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }
        //Check valid format for extraction (supports incomplete inputs like 0.m -> 0g)
        private bool IsValidText(string text)
        {
            return Regex.IsMatch(text, @"^([0-9]*?\.?[0-9]*?m?g?)$");
        }
        //Extract value from entered string
        private void ExtractGram(string text)
        {
            //trim all unwanted characters (only allow 0-9 dots and m or g)
            text = Regex.Replace(text, @"[^0-9\.mg]", String.Empty);
            //Expected Format -> random numbers, dots and couple m/g
            //trim all text after the letter g 
            text = text.Split('g')[0];
            //Expected Format -> random numbers, dots and m
            //trim double dots (only one dot is allowed)
            text = Regex.Replace(text, @"(?<=\..*)(\.)", String.Empty);
            //Expected Format -> random numbers with one or more dots and m
            //Check if m is at the end of the string to indicate milli (g was trimmed earlier)
            bool isMilli = text.EndsWith("m");
            //Remove all m, then only a double number should remain
            text = text.Replace("m", String.Empty);
            //Expected Format -> random numbers with possible dot
            //trim all leading zeros
            text = text.TrimStart(new char[] { '0' });
            //Expected Format -> random numbers with possible dot
            //Check if dot is at the beginning
            if (text.StartsWith(".")) { text = $"0{text}"; }
            //Expected Format -> random numbers with possible dot
            //Check if dot is at the end
            if (text.EndsWith(".")) { text = $"{text}0"; }
            //Expected Format -> random numbers with possible dot
            //Try to convert the remaining String to a Number, if it fails -> 0
            Double.TryParse(text, out double result);
            //Update Gram Property (divide when necessary)
            Gram = (isMilli) ? result / 1000d : result;
        }
    }
