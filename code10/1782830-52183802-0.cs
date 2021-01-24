    private readonly ObservableCollection<VariantNumbers> variantNumbers =
        new ObservableCollection<VariantNumbers>();
    ...
    lstBoxVariants.ItemsSource = variantNumbers;
    ...
    if (e.Key == System.Windows.Input.Key.Enter)
    {
        variantNumbers.Add(new VariantNumbers { Number = txtVariantNo.Text });
        txtVariantNo.Text = "";     
    }
