    public class CheckBoxesColumn : DataGridViewColumn
    {
        public CheckBoxesColumn() : base(new CheckBoxesCell())
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
            // Ensure that the cell used for the template is a CheckBoxesCell.
                if (value != null && 
                    !value.GetType().IsAssignableFrom(typeof(CheckBoxesCell)))
                {
                    throw new InvalidCastException("Must be a CheckBoxesCell");
                }
                base.CellTemplate = value;
            }
        }
    }
