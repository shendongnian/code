    public SuperCar(Car car)
    {
        var props = typeof(Car).GetProperties().Where(p => !p.GetIndexParameters().Any());
        foreach (var prop in props)
        {
            if (prop.CanWrite)
                prop.SetValue(this, prop.GetValue(car));
        }
        // Set SuperCarcentric properties
        // .
        // .
        // .
    }
