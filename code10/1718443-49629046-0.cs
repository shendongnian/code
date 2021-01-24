    @helper DisplayNameReflected(PropertyInfo property, ResourceManager resManager)
        {
            if (!property.PropertyType.Name.Contains("IEnumerable"))
            {
                var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (dd != null)
                {
                    <p>
                        @resManager.GetString(dd.Name, CultureInfo.CurrentCulture)
                    </p>
                }
            }
    }
