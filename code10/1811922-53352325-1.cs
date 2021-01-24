    public static IForm<SandwichOrder> BuildForm()
    {
    ...
    return new FormBuilder<SandwichOrder>()
        .Message("Welcome to the sandwich order bot!")
        .Field(nameof(Sandwich))
        .Field(nameof(Bread))
        .Field(nameof(Toppings),
            validate: async (state, value) =>
            {
                var values = ((List<object>)value).OfType<ToppingOptions>();
                var result = new ValidateResult { IsValid = true, Value = values };
                if (values != null && values.Contains(ToppingOptions.Everything))
                {
                    result.Value = (from ToppingOptions topping in Enum.GetValues(typeof(ToppingOptions))
                                    where topping != ToppingOptions.Everything && !values.Contains(topping)
                                    select topping).ToList();
                }
                return result;
            })
        .Message("For sandwich toppings you have selected {Toppings}.")
        ...
        .Build();
    }
