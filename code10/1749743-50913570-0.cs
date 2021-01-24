    private void OnAgeTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            txtAge.TextChanged -= OnAgeTextChanged;
            if (e.NewTextValue?.Length > 3 ?? false)
                txtAge.Text = e.OldTextValue;
            string strNumber = txtAge.Text;
            if (strNumber.Contains(".") || strNumber.Contains("-"))
            {
                strNumber = strNumber.Replace(".", "").Replace("-", "");
                txtAge.Text = strNumber;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception caught: {0}", ex);
        }
        finally
        {
            txtAge.TextChanged += OnAgeTextChanged;
        }
     }
