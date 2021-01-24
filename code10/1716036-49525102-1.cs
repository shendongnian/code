    public static Form GetFirstForm(List<Type> viewTypes)
    {
        foreach (var myType in viewTypes)
        {
            var form = GetForm(myType);
            if(form != null)
            {
                return form;
            }
        }
    }
    public static Form GetForm(Type type)
    {
        foreach (var form in Application.OpenForms)
        {
            if (type.IsAssignableFrom(form.GetType()))
            {
                return form;
            }
        }
        return null;
    }
