    Enum.GetValues(typeof(MyEnum))
        .Cast<MyEnum>()
        .Select(e=> new
                    {
                        Value = e,
                        Text = e.ToString().Replace("_", " ")
                    });
