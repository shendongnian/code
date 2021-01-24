        settings.Columns.Add(column =>
        {
            column.FieldName = "BenefitKey";
            column.Name = "BenefitKey";
            column.Caption = "Claim Type";
            column.Width = 200;
            column.Settings.AllowHeaderFilter = DefaultBoolean.False;
            column.EditFormSettings.Visible = DefaultBoolean.True;
            column.Settings.AllowSort = DefaultBoolean.False;
            column.EditorProperties().ComboBox(p =>
            {   /*Populate the combobox with valid values based on the selected dependentKey*/
                p.CallbackRouteValues = new { Controller = "BenefitClaimDetails", Action = "GetBenefitTypes", TextField = "BenefitName", ValueField = "BenefitInfoKeySK", headerEmployeeID = Model.BenefitHeaderEmployee };
                p.ClientSideEvents.BeginCallback = "ClaimTypeComboBox_BeginCallback";
                p.Width = 200;
                p.ValidationSettings.RequiredField.IsRequired = true;
                p.ValidationSettings.RequiredField.ErrorText = "Claim Type cannot be blank";
                p.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            });
            
            /*Display the BenefitName in the gridView. The Callback method TextField and ValueField only influence the comboBox in the Editor window*/
            var comboBoxProperties = column.PropertiesEdit as MVCxColumnComboBoxProperties;
            comboBoxProperties.Width = 200;
            comboBoxProperties.DataSource = repository.GetBenefitListByEmployee(Model.BenefitHeaderEmployee);
            comboBoxProperties.TextField = "BenefitName";
            comboBoxProperties.ValueField = "BenefitInfoKeySK";
        });
