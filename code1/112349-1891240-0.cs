    foreach (var item in data)
    {
        var controls = ListPlaceholder.Controls;
    
        // Add the label
        var label = item.Key;
        controls.Add(new LiteralControl(label));
        
        var value = item.Value.ToString();
        
        bool boolVal;
        if (bool.TryParse(value, out boolVal))
        {
            // Looks like a bool so render CheckBox
            controls.Add(new CheckBox { Checked = boolVal });
        }
        else
        {
            // General data so render TextBox
            controls.Add(new TextBox { Text = value });
        }
    
        // Line break
        controls.Add(new LiteralControl("<br />"));
    }
