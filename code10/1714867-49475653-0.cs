    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App2
    {
        public class CustomTextBox : TextBox
        {
            public CustomTextBox()
            {
                this.TextChanged += CustomTextBox_TextChanged;
            }
    
    
    
            public bool IsDecimalAllowed
            {
                get { return (bool)GetValue(IsDecimalAllowedProperty); }
                set { SetValue(IsDecimalAllowedProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for IsDecimalAllowed.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsDecimalAllowedProperty =
                DependencyProperty.Register("IsDecimalAllowed", typeof(bool), typeof(CustomTextBox), new PropertyMetadata(true));
    
    
    
            private void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                CustomTextBox textBox = sender as CustomTextBox;
    
                if (textBox == null)
                    throw new InvalidCastException();
    
                bool? isAllowDecimalTag = textBox.IsDecimalAllowed;
    
                if (isAllowDecimalTag == null)
                    return;
    
                if (isAllowDecimalTag == false)
                {
                    // some logic here
                }
                else if (isAllowDecimalTag == true)
                {
                    // some logic here
                }
    
            }
        }
    }
