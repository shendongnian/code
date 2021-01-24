    // Private Field
    private bool is_pkw = false;
    // Public Property
    public bool is_motorrad { get; set; } = false;
    public void SetStellplatz(Fahrzeuge Anmeldung)
    {
        // if some condition
        is_pkw = true;
        // if some other condition
        is_motorrad = true;
    }
