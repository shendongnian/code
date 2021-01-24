    if (c is ComboBox)
    {
        var combo = (ComboBox)c;
        var count = combo.Items.Count;
        combo.Items.Clear();
        combo.BeginUpdate();
        for (int i = 0; i < count; i++)
        {
            var number = i == 0 ? "" : $"{i}";
            var item = crm.GetString($"{c.Name}.Items{number}");
            combo.Items.Add(item);
        }
        combo.EndUpdate();
    }
    crm.ApplyResources(c, c.Name);
