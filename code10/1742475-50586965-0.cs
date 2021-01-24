    .Field(nameof(Toppings),
                    validate: async (state, value) =>
                    {
                        var values = ((List<object>)value).OfType<ToppingOptions>();
                        var result = new ValidateResult { IsValid = true, Value = values };
                        if (values != null && values.Contains(ToppingOptions.everything))
                        {
                            result.Value = (from ToppingOptions topping in Enum.GetValues(typeof(ToppingOptions))
                                            where topping != ToppingOptions.everything && !values.Contains(topping)
                                            select topping).ToList();
                            value = result.Value;
                        }
                        return result;
                    })
