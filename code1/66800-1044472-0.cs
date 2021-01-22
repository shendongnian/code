    // "I know String is in the same assembly as Int32..."
    Type stringType = typeof(int).Assembly.GetType("System.String");
    // "It's in the current assembly"
    Type myType = Type.GetType("MyNamespace.MyType");
    // "It's in System.Windows.Forms.dll..."
    Type formType = Type.GetType ("System.Windows.Forms.Form, " + 
        "System.Windows.Forms, Version=2.0.0.0, Culture=neutral, " + 
        "PublicKeyToken=b77a5c561934e089");
