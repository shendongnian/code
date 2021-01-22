    // Define a column that will create an appropriate type of edit control as needed.
    public class OptionalDropdownColumn : DataGridViewColumn
    {
        public OptionalDropdownColumn()
            : base(new PropertyCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a PropertyCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(PropertyCell)))
                {
                    throw new InvalidCastException("Must be a PropertyCell");
                }
                base.CellTemplate = value;
            }
        }
    }
    // And the corresponding Cell type
    public class OptionalDropdownCell : DataGridViewTextBoxCell
    {
        public OptionalDropdownCell()
            : base()
        {           
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataItem dataItem = (DataItem) this.OwningRow.DataBoundItem;
            if (dataItem.useCombo)
            {
                DataGridViewComboBoxEditingControl ctl = (DataGridViewComboBoxEditingControl)DataGridView.EditingControl;
                ctl.DataSource = dataItem.allowedItems;
                ctl.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                DataGridViewTextBoxEditingControl ctl = (DataGridViewTextBoxEditingControl)DataGridView.EditingControl;
                ctl.Text = this.Value.ToString();
            }
        }
        public override Type EditType
        {
            get
            {
                DataItem dataItem = (DataItem)this.OwningRow.DataBoundItem;
                if (dataItem.useCombo)
                {
                    return typeof(DataGridViewComboBoxEditingControl);
                }
                else
                {
                    return typeof(DataGridViewTextBoxEditingControl);
                }
            }
        }
    }
