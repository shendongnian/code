     public static IForm<HardwareQuery> BuildForm()
        {
            return new FormBuilder<HardwareQuery>()
                  .Message("Welcome!")
                  .Field(nameof(Categ))
                  .Field(new FieldReflector<HardwareQuery>(nameof(SubCateg))
                      .SetType(null)
                      .SetDefine(async (state, field) =>
                      {
                          //// Define your SubCateg logic here
                          return true;
                      }))
                  .Field(nameof(PhoneNumber))
                  .Field(nameof(Email))
                  .Field(nameof(Justification))
                  .Build();
        }
