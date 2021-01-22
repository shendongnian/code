    Type T = typeof ( string ); // replace with actual T
    string typeName = string.Format (
      "System.Collections.Generic.List`1[[{0}]], mscorlib", T.AssemblyQualifiedName );
    
    IList list = Activator.CreateInstance ( Type.GetType ( typeName ) )
      as IList;
    
    System.Diagnostics.Debug.Assert ( list != null ); //
    
    list.Add ( "string 1" ); // new T
    list.Add ( "string 2" ); // new T
    foreach ( object item in list )
    {
      Console.WriteLine ( "item: {0}", item );
    }
