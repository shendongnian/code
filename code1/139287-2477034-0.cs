    Type formType = typeof(Form);
    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
       if (formType.IsAssignableFrom(type))
       {
           // type is a Form
       }
