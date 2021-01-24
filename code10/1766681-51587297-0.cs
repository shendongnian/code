    public static IForm<HardwareQuery> BuildForm()
    {
        return new FormBuilder<HardwareQuery>()
                .Message("Welcome to the PHI Create Hardware Request!")
                    .OnCompletion(async (context, HardwareQueryForm) =>
                    {
                        //you code logic 
    
                        string hardware = HardwareQueryForm.Hardware.ToString();
                        string details = HardwareQueryForm.Details;
                        int quantity = HardwareQueryForm.Quantity;
                        string justification = HardwareQueryForm.Justification;
    
                        //connect to database and save user inputs into database
                    })
                    .Build();
    }
