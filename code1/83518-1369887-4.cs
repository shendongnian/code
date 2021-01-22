    // in module where we want to show items with all complexities
    // or just filter on one complexity
    comboComplexity.DisplayMember = LocalizableEnum.ColumnNames.EnumValue;
    comboComplexity.ValueMember = LocalizableEnum.ColumnNames.EnumDescription;
    comboComplexity.DataSource = EnumHelper.GetEnumList<Complexity>();
    comboComplexity.SelectedValue = Complexity.AllComplexities;
    // ....
    // and here in edit module where we don't want to see "All Complexities"
    comboComplexity.DisplayMember = LocalizableEnum.ColumnNames.EnumValue;
    comboComplexity.ValueMember = LocalizableEnum.ColumnNames.EnumDescription;
    comboComplexity.DataSource = EnumHelper.GetEnumList<Complexity>(Complexity.AllComplexities);
    comboComplexity.SelectedValue = Complexity.VeryComplex; // set default value
