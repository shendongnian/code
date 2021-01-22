    // radioButton1.Tag = "Option1"
    // radioButton1.CheckedChanged += OnRadioButtonCheckedChanged
    radioButton1.DataBindings.Add("Checked", this, "PropertyRBEnum")
        .Format += FormatSelectedRadioButton<RadioButtonEnum>;
    // radioButton2.Tag = "Option2"
    // radioButton2.CheckedChanged += OnRadioButtonCheckedChanged
    radioButton2.DataBindings.Add("Checked", this, "PropertyRBEnum")
        .Format += FormatSelectedRadioButton<RadioButtonEnum>;
