    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    
    namespace UILib
    {
        public class TextBoxDecimalRangeBehaviour : Behavior<TextBox>
        {
            public string EmptyValue { get; set; } = "0";
    
            public double Minimum
            {
                get { return (double)GetValue(MinimumProperty); }
                set { SetValue(MinimumProperty, value); }
            }
            public static readonly DependencyProperty MinimumProperty =
                DependencyProperty.Register("Minimum", typeof(double), typeof(TextBoxDecimalRangeBehaviour), new PropertyMetadata(0.0));
    
    
            public double Maximum
            {
                get { return (double)GetValue(MaximumProperty); }
                set { SetValue(MaximumProperty, value); }
            }
            public static readonly DependencyProperty MaximumProperty =
                DependencyProperty.Register("Maximum", typeof(double), typeof(TextBoxDecimalRangeBehaviour), new PropertyMetadata(10.0));
    
    
    
            public int MaxInteger
            {
                get { return (int)GetValue(MaxIntegerProperty); }
                set { SetValue(MaxIntegerProperty, value); }
            }
            public static readonly DependencyProperty MaxIntegerProperty =
                DependencyProperty.Register("MaxInteger", typeof(int), typeof(TextBoxDecimalRangeBehaviour), new PropertyMetadata(1));
    
    
    
            public int MaxDecimals
            {
                get { return (int)GetValue(MaxDecimalsProperty); }
                set { SetValue(MaxDecimalsProperty, value); }
            }
    
            public static readonly DependencyProperty MaxDecimalsProperty =
                DependencyProperty.Register("MaxDecimals", typeof(int), typeof(TextBoxDecimalRangeBehaviour), new PropertyMetadata(2));
    
    
    
            /// <summary>
            ///     Attach our behaviour. Add event handlers
            /// </summary>
            protected override void OnAttached()
            {
                base.OnAttached();
    
                AssociatedObject.PreviewTextInput += PreviewTextInputHandler;
                AssociatedObject.PreviewKeyDown += PreviewKeyDownHandler;
                DataObject.AddPastingHandler(AssociatedObject, PastingHandler);
            }
    
            /// <summary>
            ///     Deattach our behaviour. remove event handlers
            /// </summary>
            protected override void OnDetaching()
            {
                base.OnDetaching();
    
                AssociatedObject.PreviewTextInput -= PreviewTextInputHandler;
                AssociatedObject.PreviewKeyDown -= PreviewKeyDownHandler;
                DataObject.RemovePastingHandler(AssociatedObject, PastingHandler);
            }
    
            void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
            {
                string text;
                if (this.AssociatedObject.Text.Length < this.AssociatedObject.CaretIndex)
                    text = this.AssociatedObject.Text;
                else
                {
                    //  Remaining text after removing selected text.
                    string remainingTextAfterRemoveSelection;
    
                    text = TreatSelectedText(out remainingTextAfterRemoveSelection)
                        ? remainingTextAfterRemoveSelection.Insert(AssociatedObject.SelectionStart, e.Text)
                        : AssociatedObject.Text.Insert(this.AssociatedObject.CaretIndex, e.Text);
                }
    
                e.Handled = !ValidateText(text);
            }
    
            /// <summary>
            ///     PreviewKeyDown event handler
            /// </summary>
            void PreviewKeyDownHandler(object sender, KeyEventArgs e)
            {
                if (string.IsNullOrEmpty(this.EmptyValue))
                {
                    return;
                }
    
    
                string text = null;
    
                // Handle the Backspace key
                if (e.Key == Key.Back)
                {
                    if (!this.TreatSelectedText(out text))
                    {
                        if (AssociatedObject.SelectionStart > 0)
                            text = this.AssociatedObject.Text.Remove(AssociatedObject.SelectionStart - 1, 1);
                    }
                }
                // Handle the Delete key
                else if (e.Key == Key.Delete)
                {
                    // If text was selected, delete it
                    if (!this.TreatSelectedText(out text) && this.AssociatedObject.Text.Length > AssociatedObject.SelectionStart)
                    {
                        // Otherwise delete next symbol
                        text = this.AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, 1);
                    }
                }
    
                if (text == string.Empty)
                {
                    this.AssociatedObject.Text = this.EmptyValue;
                    if (e.Key == Key.Back)
                        AssociatedObject.SelectionStart++;
                    e.Handled = true;
                }
            }
    
            private void PastingHandler(object sender, DataObjectPastingEventArgs e)
            {
                if (e.DataObject.GetDataPresent(DataFormats.Text))
                {
                    string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
    
                    if (!ValidateText(text))
                        e.CancelCommand();
                }
                else
                    e.CancelCommand();
            }
    
            /// <summary>
            ///     Validate certain text by our regular expression and text length conditions
            /// </summary>
            /// <param name="text"> Text for validation </param>
            /// <returns> True - valid, False - invalid </returns>
            private bool ValidateText(string text)
            {
                double number;
                if (!Double.TryParse(text, out number))
                {
                    return false;
                }
                if(number < Minimum)
                {
                    return false;
                }
                if (number > Maximum)
                {
                    return false;
                }
                int dotPointer = text.IndexOf('.');
                // No point entered so the decimals must be ok
                if(dotPointer == -1)
                {
                    return true;
                }
                if (dotPointer > MaxInteger)
                {
                    return false;
                }
                if(text.Substring(dotPointer +1).Length > MaxDecimals)
                {
                    return false;
                }
                return true;
            }
    
            /// <summary>
            ///     Handle text selection
            /// </summary>
            /// <returns>true if the character was successfully removed; otherwise, false. </returns>
            private bool TreatSelectedText(out string text)
            {
                text = null;
                if (AssociatedObject.SelectionLength <= 0)
                    return false;
    
                var length = this.AssociatedObject.Text.Length;
                if (AssociatedObject.SelectionStart >= length)
                    return true;
    
                if (AssociatedObject.SelectionStart + AssociatedObject.SelectionLength >= length)
                    AssociatedObject.SelectionLength = length - AssociatedObject.SelectionStart;
    
                text = this.AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, AssociatedObject.SelectionLength);
                return true;
            }
        }
    }
