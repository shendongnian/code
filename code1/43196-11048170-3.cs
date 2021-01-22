    radioButton1.Tag = "Option1";
    radioButton2.Tag = "Option2";
    foreach (RadioButtonUx rb in new RadioButtonUx[] { radioButton1, radioButton2 })
    {
        Binding b = new Binding("Checked", this, "PropertyRBEnum");
        b.Format += FormatSelectedRadioButton<OptionEnum>;
        b.Parse += ParseSelectedRadioButton<OptionEnum>;
        rb.DataBindings.Add(b);
    }
