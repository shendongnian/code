    foreach (PropertyInfo property in properties.Where(x => x.Name != nameof(Student.ID)))
    {
        property.SetValue(newStudent, Convert.ChangeType(_textBoxes[num].Text, property.PropertyType));
        num++;
    }
