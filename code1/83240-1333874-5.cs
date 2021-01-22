    checkBoxCanEdit.Bind(c => c.Checked, person, p => p.UserCanEdit);
    textBoxName.BindEnabled(person, p => p.UserCanEdit);
    checkBoxEmployed.BindEnabled(person, p => p.UserCanEdit);
    trackBarAge.BindEnabled(person, p => p.UserCanEdit);
    
    textBoxName.Bind(c => c.Text, person, d => d.Name);
    checkBoxEmployed.Bind(c => c.Checked, person, d => d.Employed);
    trackBarAge.Bind(c => c.Value, person, d => d.Age);
    
    labelName.BindLabelText(person, p => p.Name);
    labelEmployed.BindLabelText(person, p => p.Employed);
    labelAge.BindLabelText(person, p => p.Age);
