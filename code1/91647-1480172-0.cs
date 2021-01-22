    using System.Windows.Controls;
    using System.Windows;
    namespace WpfApplication1
    {
        partial class Dictionary1
        {
            void TextBox_TextChanged(object sender, RoutedEventArgs e)
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null)
                    textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
