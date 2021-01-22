    var args = FormatterServices.GetUninitializedObject(typeof(SizeChangedEventArgs)) as SizeChangedEventArgs;
    Debug.Assert(args != null);
    
    var field = typeof(SizeChangedEventArgs).GetField("_previousSize", BindingFlags.Instance | BindingFlags.NonPublic);
    Debug.Assert(field != null);
    field.SetValue(args, new Size(0,0));
    field = typeof(SizeChangedEventArgs).GetField("_element", BindingFlags.Instance | BindingFlags.NonPublic);
    Debug.Assert(field != null);
    field.SetValue(args, GraphicsWrapper);
    field = typeof(RoutedEventArgs).GetField("_source", BindingFlags.Instance | BindingFlags.NonPublic);
    Debug.Assert(field != null);
    field.SetValue(args, GraphicsWrapper);
    field = typeof(RoutedEventArgs).GetField("_routedEvent", BindingFlags.Instance | BindingFlags.NonPublic);
    Debug.Assert(field != null);
    field.SetValue(args, SizeChangedEvent);
    
    GraphicsWrapper.RaiseEvent(args);
