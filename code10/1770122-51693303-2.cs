    public void Configure(IApplicationBuilder app, OptionsValidator optionsValidator)
    {
        optionsValidator.Validate();
        // …
    }
