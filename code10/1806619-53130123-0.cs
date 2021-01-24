    public partial class Generic
    {
        private void increaseValue(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (((((sender as Button).Parent as Grid).Parent as Grid)).Parent as Border).TemplatedParent as TextBox;
            textBox.Text = Convert.ToString(Convert.ToInt32(textBox.Text) + 1);
        }
    }
