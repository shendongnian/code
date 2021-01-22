    IView LoadView(Type dependantType)
    {
      // get the view or create one
      IView view = GetView(dependantType);
      if (view == null)
      {
        view = InstantiateViewAndAddToForm(dependantType);
        AddView(view);
      }
      
      //
      // do some binding to your model or whatever here
      //
      // make the correct view visible
      foreach (IView v in Views)
        view.Visible = v == view;
    }
