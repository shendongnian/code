    // IEnumerable doesn't have Count property so you need to use Count() 
    // extension method from System.Linq namespace.
    int length = values.Count();
    for (int i = 0; i < length; i++) {
        bool isChecked = modelValues.Contains(values.ElementAt(i));
        sb.Append(CreateCheckBox(name, values.ElementAt(i), isChecked, HtmlAttributes));
        sb.Append(" <label for=\"" + name + "\"> " + labels.ElementAt(i) + "</label><br />");
    }
