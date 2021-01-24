    private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
       try
       {
           txtDescription.Text = txtKG.Text;
       }
       catch { }
    }
