    // Add at top
    using YourDllNamespace;
    public YourForm()
    {
        // Creating our class for calculation
        YourDllCalculation calc = new YourDllCalculation();
        calc += CalculationResultChanged;
        calc.Calculate();
    }
    private void CalculationResultChanged(object sender, CustomEventArgs e)
    {
        // Here do whatever you want with passed values
        // e.OldResult;
        // e.NewResult;
        // it will fire each second
    }
