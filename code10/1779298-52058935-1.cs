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
                          switch (state.Categ)
                          {
                              Category.hardware:
                                break;
                              default:
                                  break;
                          }
                          
                         
                          return true;
                      }))
                  .Field(nameof(PhoneNumber))
                  .Field(nameof(Email))
                  .Field(nameof(Justification))
                  .Build();
        }
