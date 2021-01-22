    namespace PlaceholderForRichTexxBoxInWPF
    {
    public MainWindow()
            {
                InitializeComponent();
                Application.Current.MainWindow.WindowState = WindowState.Maximized;// maximize window on load
    
                richTextBox1.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(rtb_GotKeyboardFocus);
                richTextBox1.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(rtb_LostKeyboardFocus);
                richTextBox1.AppendText("Place Holder");
                richTextBox1.Foreground = Brushes.Gray;
            }
     private void rtb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                if (sender is RichTextBox)
                {
                    TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd); 
    
                    if (textRange.Text.Trim().Equals("Place Holder"))
                    {
                        ((RichTextBox)sender).Foreground = Brushes.Black;
                        richTextBox1.Document.Blocks.Clear();
                    }
                }
            }
    
    
            private void rtb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                //Make sure sender is the correct Control.
                if (sender is RichTextBox)
                {
                    //If nothing was entered, reset default text.
                    TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd); 
    
                    if (textRange.Text.Trim().Equals(""))
                    {
                        ((RichTextBox)sender).Foreground = Brushes.Gray;
                        ((RichTextBox)sender).AppendText("Place Holder");
                    }
                }
            }
    }
