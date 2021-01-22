    void SomethingChanged(object sender, EventArgs e) {
        EnableControls();
    }
    ...
    MyRadioButton.Click += SomethingChanged;
    MyCheckbox.Click += SomethingChanged;
    ...
