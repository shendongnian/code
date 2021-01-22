       public class DataGridViewBusinessComboBoxColumn : DataGridViewComboBoxColumn
        {
            public DataGridViewBusinessComboBoxColumn()
            {
                CellTemplate = new DataGridViewBusinessComboBoxCell();
            }
        }
    
        public class DataGridViewBusinessComboBoxCell : DataGridViewComboBoxCell
        {
            private System.ComponentModel.PropertyDescriptor displayProp;
    
            private CurrencyManager ListManager
            {
                get
                {
                    BindingMemberInfo bmi = new BindingMemberInfo(base.DisplayMember);
                    if (DataGridView != null)
                    {
                        return (CurrencyManager)
                               DataGridView.BindingContext[DataSource, bmi.BindingPath];
                    }
                    return null;
                }
            }
    
            private System.ComponentModel.PropertyDescriptor DisplayProp
            {
                get
                {
                    if (displayProp == null)
                    {
                        displayProp = ListManager.GetItemProperties().Find(DisplayMember,
                                                                           true);
                    }
                    return displayProp;
                }
            }
    
            protected override object GetFormattedValue(object value, int rowIndex,
                                                        ref DataGridViewCellStyle cellStyle,
                                                        TypeConverter valueTypeConverter,
                                                        TypeConverter formattedValueTypeConverter,
                                                        DataGridViewDataErrorContexts
                                                            context)
            {
                if (value == null || value == cellStyle.DataSourceNullValue)
                    return "";
    
                return base.GetFormattedValue(DisplayProp.GetValue(value),
                                              rowIndex, ref cellStyle, valueTypeConverter,
                                              formattedValueTypeConverter, context);
            }
    
            public override object ParseFormattedValue(object formattedValue,
                                                       DataGridViewCellStyle cellStyle,
                                                       TypeConverter formattedValueTypeConverter,
                                                       TypeConverter valueTypeConverter)
            {
                foreach (object item in ListManager.List)
                {
                    if ((string) DisplayProp.GetValue(item) == (string) formattedValue)
                        return item;
                }
    
                return base.ParseFormattedValue(formattedValue, cellStyle,
                                                formattedValueTypeConverter, valueTypeConverter);
            }
    }
