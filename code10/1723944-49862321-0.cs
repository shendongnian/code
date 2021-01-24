    [Serializable]
    public class LocationForm
    {
        [Prompt("Which country? {||}")]
        public Country? country;
        [Prompt("Which city? {||}")]
        public string city;
        public static IForm<LocationForm> BuildLocationForm()
        {
            return new FormBuilder<LocationForm>()
                .Field(new FieldReflector<LocationForm>(nameof(country))
                    .SetValidate(async (state, response) =>
                    {
                        var result = new ValidateResult { IsValid = true, Value = response };
                        //Validation to check if the current country and previous selected country are same so that user is not prompted again for city
                        if (state.country.ToString() != response.ToString())
                            state.city = String.Empty;
                        return result;
                    }))
                .Field(new FieldReflector<LocationForm>(nameof(city))
                    //To get buttons SetType(null)
                    .SetType(null)
                    .SetDefine(async (state, field) =>
                    {
                        //Any previous value before the confirm should be cleared in case selection is changed for country
                        field.RemoveValues();
                        switch (state.country)
                        {
                            case Country.France:
                                field
                                        .AddDescription(nameof(City.Berlin), nameof(City.Berlin))
                                        .AddTerms(nameof(City.Berlin), nameof(City.Berlin));
                                        //Add more description and terms if any
                                break;
                            case Country.Germany:
                                field
                                        .AddDescription(nameof(City.Paris), nameof(City.Paris))
                                        .AddTerms(nameof(City.Paris), nameof(City.Paris));
                                        //Add more description and terms if any
                                break;
                        }
                        return true;
                    }))
                .AddRemainingFields()
                .Confirm(async (state) =>
                {
                    return new PromptAttribute($"You selected {state.country} and {state.city}, is that correct?" + "{||}");
                })
                .Build();
        }
    }
    [Serializable]
    public enum Country
    {
        France, Germany
    }
    [Serializable]
    public enum City
    {
        Paris, Berlin
    }
