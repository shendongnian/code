    private void SetInvalid_Click(object sender, RoutedEventArgs e)
    {
        var before = this.Value;
        var sliderBefore = Slider.Value;
        Slider.Value = -1;
        var after = this.Value;
        var sliderAfter = Slider.Value;
        MessageBox.Show(string.Format("Value changed from {0} to {1}; " + 
            "Slider changed from {2} to {3}", 
            before, after, sliderBefore, sliderAfter));
    }
    public int Value { get; set; }
