    int num = 1;
    PropertyInfo[] properties = typeof(Student).GetProperties();
    foreach (PropertyInfo property in properties)
    {
        if (property.Name != nameof(Student.ID))
        {
            property.SetValue(newStudent, Convert.ChangeType(_textBoxes[num].Text, property.PropertyType));
        }
        num++;
    }
