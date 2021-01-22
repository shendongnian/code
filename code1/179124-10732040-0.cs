    foreach (PropertyInfo property in GetType().GetProperties())
    {
        if (typeof(SubPresenter).IsAssignableFrom(property.PropertyType))
        {//Do Sth.}
    }
