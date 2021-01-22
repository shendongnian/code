    int i = 0;
    foreach (string s in values) {
        bool isChecked = modelValues.Contains(s);
        sb.Append(CreateCheckBox(name, s, isChecked, HtmlAttributes));
        sb.Append(" <label for=\"" + name + "\"> " + labels[i] + "</label><br />");
        i++;
    }
