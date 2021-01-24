    Type t = typeof(AnyClass);
    HelpAttribute[] attributes = t.GetCustomAttributes(typeof(HelpAttribute), true)
                                  .Cast<HelpAttribute>()
                                  .ToArray(); // on this line the attribute is instantiated
    Console.WriteLine(attributes.FirstOrDefault()?.Description);
