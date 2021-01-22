    public static void tween( FrameworkElement target, object parameters )
    {
        return tween( target, new ParameterDictionary( parameters ) );
    }
    public static void tween( FrameworkElement target,
                              ParameterDictionary values )
    {
        if (values.ContainsKey( "ease" ))
        {
          ....
        }
    }
