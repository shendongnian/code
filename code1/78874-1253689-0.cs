    public static string CheckBoxList(this HtmlHelper htmlhelper, IEnumerable<string> values, IEnumerable<string> labels, string name, IDictionary<string, object> HtmlAttributes)
    {
        if (labels == null)
            return "";
    
        StringBuilder sb = new StringBuilder();
        string[] modelValues = new string[] { };
        ModelState modelState;
    
        if (htmlhelper.ViewData.ModelState.TryGetValue(name, out modelState))
        {
            modelValues = ((string[])modelState.Value.RawValue);
        }
    
        IEnumerator<string> valueEnumerator = values.GetEnumerator();
        IEnumerator<string> labelEnumerator = labels.GetEnumerator();
        int index = 0;
        while (valueEnumerator.MoveNext() && labelEnumerator.MoveNext())
        {
            bool isChecked = modelValues.Contains(valueEnumerator.Current);
            sb.Append(CreateCheckBox(name, valueEnumerator.Current, isChecked, HtmlAttributes));
            sb.Append(string.Format(" <label for=\"{0}\" id=\"label-{1}\">{2}</label></br>", name, index, labelEnumerator.Current);
            index++;
        }
    
        return sb.ToString();
    }
