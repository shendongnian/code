    System.Reflection.FieldInfo headingField = this.GetType().GetField("heading");
    object[] attribs = headingField.GetCustomAttributes(typeof(Abc.Text));
    if (attribs.Length == 1)
    {
        int max = ((Abc.Text)attribs[0]).MaxLength;
    }
