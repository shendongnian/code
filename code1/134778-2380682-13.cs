    // as part of application innitialization
    IConvert<string> stringConverter = container.Resolve<IConvert<string>> ();
    stringConverter.AddConversion<int> (s => Convert.ToInt32 (s));
    stringConverter.AddConversion<Color> (s => CustomColorParser (s));
    ...
    // a consumer elsewhere in code, say a Command acting on 
    // string input fields of a form
    // 
    // NOTE: stringConverter could be injected as part of DI
    // framework, or obtained directly from IoC container as above
    int someCount = stringConverter.To<int> (someCountString);
    Func<string, Color> ToColor = stringConverter.GetConversion <Color> ();
    IEnumerable<Color> colors = colorStrings.Select (s => ToColor (s));
