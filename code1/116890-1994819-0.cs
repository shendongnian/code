    foreach(PropertyDescriptor prop in TypeDescriptor.GetProperties(obj)) {
        object val = prop.GetValue(obj);
        string s = prop.Converter.ConvertToString(val);
        Control cont = // TODO: create some control and set x/y
        cont.Text = s;
        this.Controls.Add(cont);
    }
