        settings.Columns.Add(column =>
        {
            column.FieldName = "DependentKey";
            column.Name = "DependentKey";
            column.Caption = "Claimant";
            column.Width = 300;
            column.Settings.AllowHeaderFilter = DefaultBoolean.False;
            column.EditFormSettings.Visible = DefaultBoolean.True;
            column.Settings.AllowSort = DefaultBoolean.False;
            column.ColumnType = MVCxGridViewColumnType.ComboBox;
            var comboBoxProperties = column.PropertiesEdit as ComboBoxProperties;
            /*Get an employee model for the current employee and pass that to the Depoendents method to get their list of dependents*/
            comboBoxProperties.DataSource = repository.GetDependentDropdownList(repository.GetCurrentEmployee(employeeID: Model.BenefitHeaderEmployee).DimEmployee);
            comboBoxProperties.TextField = "DependentName";
            comboBoxProperties.ValueField = "DependentKeySK";
            comboBoxProperties.DropDownRows = 15;
            comboBoxProperties.ValueType = typeof(int);
            comboBoxProperties.ValidationSettings.RequiredField.IsRequired = true;
            comboBoxProperties.ValidationSettings.RequiredField.ErrorText = "Claimant cannot be blank";
            comboBoxProperties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            comboBoxProperties.ClientSideEvents.SelectedIndexChanged = "OnSelectedClaimantChanged";
        });
