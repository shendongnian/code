    public class IntegerTextBox : TextBox
        {
            /// <summary>
            /// To be raised whenever integer value changed
            /// </summary>
            public event EventHandler ValueChanged;
    
            /// <summary>
            /// To restore if the user entered invalid characters
            /// </summary>
            private int lastSavedValue = 0;
    
            private int lastSelectionStart = 0;
            private int lastSelectionLength = 0;
    
    
            public int IntegerValue
            {
                get
                {
                    //the default value is 0 if there is no text in the textbox
                    int value = 0;
                    int.TryParse(Text, out value);
                    return value;
                }
                set
                {
                    if (this.Text.Trim() != value.ToString())
                    {
                        Text = value.ToString();
                    }
                }
            }
    
            public IntegerTextBox()
                : base()
            {
                this.LostFocus += (sender, e) =>
                    {
                        //if the user clears the text the text box and leaves it, set it to default value
                        if (string.IsNullOrWhiteSpace(this.Text))
                            IntegerValue = 0;
                    };
                this.Loaded += (sender, e) =>
                    {
                        //populate the textbox with Initial IntegerValue (default = 0)
                        this.Text = this.IntegerValue.ToString();
                    };
    
                this.TextChanged += (sender, e) =>
                    {
                        int newValue = 0;
                        if (int.TryParse(this.Text, out newValue)) //this will handle most cases like number exceeds the int max limits, negative numbers, ...etc.
                        {
                            if (string.IsNullOrWhiteSpace(Text) || lastSavedValue != newValue)
                            {
                                lastSavedValue = newValue;
                                //raise the event
                                EventHandler handler = ValueChanged;
                                if (handler != null)
                                    handler(this, EventArgs.Empty);
    
                            }
                        }
                        else 
                        {
                            //restore previous number
                            this.Text = lastSavedValue.ToString();
                            //restore selected text
                            this.SelectionStart = lastSelectionStart;
                            this.SelectionLength = lastSelectionLength;
                        }
                    };
    
                this.KeyDown += (sender, e) =>
                    {
                        //before every key press, save selection start and length to handle overwriting selected numbers
                        lastSelectionStart = this.SelectionStart;
                        lastSelectionLength = this.SelectionLength;
                    };
            }
        } 
