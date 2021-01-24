    public class DataGridViewDateTimeEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        public DataGridViewDateTimeEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }
        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
        public object EditingControlFormattedValue
        {
            get { return this.Value.ToShortDateString(); }
            set
            {
                if (value is String)
                {
                    this.Value = DateTime.Parse((String)value);
                }
            }
        }
        // Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }
        // Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            if (dataGridViewCellStyle.Format != "d")
            {
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = dataGridViewCellStyle.Format;
            }
        }
        // Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
        public int EditingControlRowIndex { get; set; }
        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Tab:
                    return true;
                default:
                    return false;
            }
        }
        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }
        // Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange { get { return false; } }
        // Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView { get; set; }
        // Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
        public bool EditingControlValueChanged { get; set; }
        // Implements the IDataGridViewEditingControl.EditingPanelCursor property.
        public Cursor EditingPanelCursor { get { return base.Cursor; } }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Notify the DataGridView that the contents of the cell have changed.
            EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnKeyPress(e);
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell have changed.
            EditingControlValueChanged = true;
            // setting Value for date if format is Month and Year only
            if (!string.IsNullOrEmpty(this.CustomFormat))
            {
                if (this.CustomFormat.IndexOf("d") < 0)
                {
                    this.Value = new DateTime(this.Value.Year, this.Value.Month, DateTime.DaysInMonth(this.Value.Year, this.Value.Month));
                }
            }
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnCloseUp(eventargs);
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell have changed.
            EditingControlValueChanged = true;
            // setting Value for date if format is Month and Year only
            if (!string.IsNullOrEmpty(this.CustomFormat))
            {
                if (this.CustomFormat.IndexOf("d") < 0)
                {
                    this.Value = new DateTime(this.Value.Year, this.Value.Month, DateTime.DaysInMonth(this.Value.Year, this.Value.Month));
                }
            }
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
