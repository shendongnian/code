    foreach (IParameter parameter in parameters)
    {
        Control control = Factory.Create(parameter);
        if (control!=null) {
            Controls.Add(control);
        }
    }
