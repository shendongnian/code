    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms.VisualStyles;
    
    namespace YourNamespaceHere
    {
        /// <summary>
        /// DataGridView TextBox column with Items support.
        /// </summary>
    
        public class DropTextBoxColumn : DataGridViewColumn
        {
            [Browsable(false)]
            public IEnumerable<string> Items { get; set; }
    
            public ComboBoxStyle DropDownStyle { get; set; }
    
            public DropTextBoxColumn() : base(new DropTextBoxCell()) 
            {
                DropDownStyle = ComboBoxStyle.DropDown;
            }
    
            private DataGridViewCell cellTemplate = new DropTextBoxCell();
            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return cellTemplate;
                }
                set
                {
                    // Ensure that the cell used for the template is a DropTextBoxCell.
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(DropTextBoxCell)))
                    {
                        throw new InvalidCastException("Must be a DropTextBoxCell");
                    }
                    cellTemplate = value;
                }
            }
        }
    
        public class DropTextBoxCell : DataGridViewTextBoxCell
        {
            [Browsable(false)]
            public string[] Items { get; set; }
    
            public DropTextBoxCell() : base() { }
    
    
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    
                //draw a drop down button
                if ( (cellState & DataGridViewElementStates.Selected) != 0) 
                {
                    var cb = cellBounds;
                    var r = new Rectangle(cb.Right - cb.Height, cb.Top, cb.Height, cb.Height);
                    //ComboBoxRenderer.DrawTextBox(graphics, cb, formattedValue as string, this.Style.Font ?? DataGridView.Font, ComboBoxState.Normal);
                    ComboBoxRenderer.DrawDropDownButton(graphics, r, ComboBoxState.Normal);            
                }
            }
            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                DropTextBoxEditingControl ctl =
                    DataGridView.EditingControl as DropTextBoxEditingControl;
                
                var value = this.Value.ToString();
    
                ctl.Loading = true;
                DropTextBoxColumn col = DataGridView.Columns[this.ColumnIndex] as DropTextBoxColumn;
                ctl.DropDownStyle = col.DropDownStyle;
                
                ctl.Items.Clear();
                if (col.Items != null)
                    ctl.Items.AddRange(col.Items.ToArray());
    
                ctl.EditingControlFormattedValue = value;
                ctl.Loading = false;
                
            }
    
            public override Type EditType
            {
                get
                {
                    // Return the type of the editing contol that CalendarCell uses.
                    return typeof(DropTextBoxEditingControl);
                }
            }
    
            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.
                    return typeof(string);
                }
            }
    
            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return string.Empty;
                }
            }
        }
    
        class DropTextBoxEditingControl : ComboBox, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;
            public bool Loading { get; set; }
            int originalIndex = -1;
    
            public DropTextBoxEditingControl()
            {
                //this.Format = DateTimePickerFormat.Short;
                DropDownStyle = ComboBoxStyle.DropDown;
                FlatStyle = FlatStyle.Flat;     
            }
    
            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return Text;
                }
                set
                {
    
                    if (value is String)
                    {
                        if (DropDownStyle == ComboBoxStyle.DropDown)
                            Text = value.ToString();
                        else
                        {
                            SelectedIndex = originalIndex = Items.IndexOf(value);                        
                        }                    
                    }
                }
            }
    
            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }
    
            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
            }
    
            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }
    
            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                //switch (key & Keys.KeyCode)
                //{
                //    case Keys.Left:
                //    case Keys.Up:
                //    case Keys.Down:
                //    case Keys.Right:
                //    case Keys.Home:
                //    case Keys.End:
                //    case Keys.PageDown:
                //    case Keys.PageUp:
                //        return true;
                //    default:
                //        return !dataGridViewWantsInputKey;
                //}
    
                return DroppedDown;
                    
            }
    
            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }
    
            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }
    
            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }
    
            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }
    
            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }
            protected override void OnSelectedItemChanged(EventArgs e)
            {
                if (Loading) return;
    
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnSelectedItemChanged(e);
            }
            protected override void OnSelectedIndexChanged(EventArgs e)
            {
                if (Loading || DroppedDown) return;
    
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnSelectedIndexChanged(e);
    
    
                SendKeys.Send("{ENTER}");
            }
            protected override void OnTextChanged(EventArgs e)
            {
                if (Loading) return;
                
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnTextChanged(e);
            }
            protected override void OnDropDownClosed(EventArgs e)
            {
                if (originalIndex != SelectedIndex)
                {
                    valueChanged = true;
                    this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                }
                base.OnDropDownClosed(e);
    
            }
            protected override void OnDropDown(EventArgs e)
            {
                //set dropdown width to accomodate items
                var g = CreateGraphics();      
                DropDownWidth = 
                    Items.Cast<string>().Max(s => 
                    {
                        var size = g.MeasureString(s, Font);
                        return size.Width.To<int>() + 30;
                    });
                base.OnDropDown(e);
            }
            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                DroppedDown = true;
            }
        }
    }
