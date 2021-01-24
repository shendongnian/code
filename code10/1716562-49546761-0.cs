     using System.Text.RegularExpressions;
     private void NumbersOnly(object sender,  TextCompositionEventArgs e)
    {
    Regex regex = new Regex("[^0-9]+");
    e.Handled = regex.IsMatch(e.Text);
    }  
