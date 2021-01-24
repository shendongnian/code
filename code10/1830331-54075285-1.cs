    public class CheckBoxesCell : DataGridViewCell
    {
        public CheckBoxesCell()
            : base()
        {
        }
        public override Type EditType
        {
            get
            {
            // Return the type of the editing control that cell uses.
            return typeof(CheckBoxesControl);
            }
        }
        public override Type ValueType
        {
            get
            {
                // Return the type of the value that Cell contains.
            
                return typeof(CheckBoxesState);
            }
        }
        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                
                return new CheckBoxesState();
            }
        }
    }
