     Control parent = ((Control)sender).Parent;
     Type parentType = parent.GetType();
     MethodInfo onClickMethod = parentType.GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic);
    
     onClickMethod.Invoke(parent, new object[] { e });
