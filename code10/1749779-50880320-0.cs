    if (property.PropertyType.IsEnum)
    {
        // At this point we know that the property is an enum.
        // Add the EnumToStringConverter converter to the property so that
        // the value is stored in the database as a string instead of number 
        modelBuilder.Entity(modelType)
            .Property(property.Name)
            .HasConversion<string>(); // <--
        continue;
    }
