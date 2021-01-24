    public class DataGridViewDateTimeCell : DataGridViewTextBoxCell
    {
        Object _defaultNewRowValue;
        Boolean _defaultNewRowValueSet;
        public DataGridViewDateTimeCell(Object defaultNewRowValue) : base()
        {
            _defaultNewRowValueSet = true;
            _defaultNewRowValue = defaultNewRowValue;
        }
        public DataGridViewDateTimeCell() : this(DateTime.Now)
        {
            _defaultNewRowValueSet = false;
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            try
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                DataGridViewDateTimeEditingControl ctl = DataGridView.EditingControl as DataGridViewDateTimeEditingControl;
                if (this.Value != DBNull.Value && this.Value != null)
                {
                    ctl.Value = Convert.ToDateTime(this.Value);
                }
            }
            catch
            {
                // Do nothing with the exception
            }
        }
        // Return the type of the editing contol that CalendarCell uses.
        public override Type EditType { get { return typeof(DataGridViewDateTimeEditingControl); } }
        // Return the type of the value that CalendarCell contains.
        public override Type ValueType { get { return typeof(DateTime); } }
        public override object DefaultNewRowValue
        {
            get
            {
                if (_defaultNewRowValueSet)
                {
                    // Use the value given to us as the Default New Row Value
                    return _defaultNewRowValue;
                }
                else
                {
                    // Use the current date and time as the default value.
                    return DateTime.Now;
                }
            }
        }
        public override Object Clone()
        {
            DataGridViewDateTimeCell retVal = base.Clone() as DataGridViewDateTimeCell;
            retVal._defaultNewRowValueSet = this._defaultNewRowValueSet;
            retVal._defaultNewRowValue = this._defaultNewRowValue;
            return retVal;
        }
    }
