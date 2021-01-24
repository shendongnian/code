    var propNamesAndValues = propsNames.Zip(propValues, (pName, pValue) => new { propName = pName, propValue = pValue });
    var sb = new StringBuilder();
    foreach (var item in propNamesAndValues)
    {
        var sb2 = new StringBuilder();
        if (item.propValue.GetType() == typeof(string[]))
        {              
            foreach (var listItem in item.propValue as string[])
            {
                sb2.Append(listItem + ", ");
            }
        }
        else
        {
            sb2.Append(item.propValue);
        }
        sb.AppendLine(item.propName + ": " + sb2.ToString());
    }
