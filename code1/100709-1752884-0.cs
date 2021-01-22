     /// <summary>
        /// data bound radio button
        /// </summary>
        public class DataBoundRadioButton : RadioButton
        {
            /// <summary>
            /// Called when the <see cref="P:System.Windows.Controls.Primitives.ToggleButton.IsChecked"/> property becomes true.
            /// </summary>
            /// <param name="e">Provides data for <see cref="T:System.Windows.RoutedEventArgs"/>.</param>
            protected override void OnChecked(RoutedEventArgs e)
            {
                // Do nothing. This will prevent IsChecked from being manually set and overwriting the binding.
            }
    
            /// <summary>
            /// Called by the <see cref="M:System.Windows.Controls.Primitives.ToggleButton.OnClick"/> method to implement a <see cref="T:System.Windows.Controls.RadioButton"/> control's toggle behavior.
            /// </summary>
            protected override void OnToggle()
            {
                BindingExpression be = GetBindingExpression(RadioButton.IsCheckedProperty);
                Binding bind = be.ParentBinding;
    
                Debug.Assert(bind.ConverterParameter != null, "Please enter the desired tag as the ConvertParameter");
    
                XmlDataProvider prov = bind.Source as XmlDataProvider;
                XmlNode node = prov.Document.SelectSingleNode(bind.XPath);
                node.InnerText = bind.ConverterParameter.ToString();
    
            }
        }
