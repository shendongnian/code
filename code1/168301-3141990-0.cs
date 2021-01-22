    string fullNameSpace = "System.Windows.Controls.";
    Type controlType = Type.GetType( fullNameSpace + xmlchild.Name );
    if( controlType != null )
    {
      // get default constructor...
      ConstructorInfo ctor = controlType.GetConstructor(Type.EmptyTypes);
      object control = ctor.Invoke(null);
    }
