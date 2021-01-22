    // Members of the Form/Control class
    private string bandwidth;
    private string inputAttenuation;
    private string averaging;
    // Later on, in your "update" method
    var updates = new List<ParameterUpdate>
    {
        new ParameterUpdate("Bandwidth", "3000", v => bandwidth = v),
        new ParameterUpdate("InputAttenuation", "10", v => inputAttenuation = v),
        new ParameterUpdate("Averaging", "Logarithmic", v => averaging = v)
    };
    bwUpdateParameters.RunWorkerAsync(updates);
