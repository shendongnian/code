    var label = new Label { Text = "Sample", Top = 10, Left = 20 };
    var button = new Button { Text = "Click", Top = 40, Left = 20 };
    panel.Controls.Add(label);
    panel.Controls.Add(button);
    var controls = panel.Controls.OfType<Control>()
        .Select(c => new ControlValueObject { Type = c.GetType().Name, Text = c.Text, Left = c.Left, Top = c.Top })
        .ToList();
    var ser = new XmlSerializer(controls.GetType());
    ser.Serialize(stream, controls);
