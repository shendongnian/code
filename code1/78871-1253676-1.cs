    // IEnumerable doesn't have Count property so you need to use Count() 
    // extension method from System.Linq namespace.
    for (int i = 0; i < values.Count(); i++) {
        bool isChecked = modelValues.Contains(values[i]);
        sb.Append(CreateCheckBox(name, values[i], isChecked, HtmlAttributes));
        sb.Append(" <label for=\"" + name + "\"> " + labels[i] + "</label><br />");
    }
