    public class DataGridViewDateTimeColumn : DataGridViewColumn
    {
        public DataGridViewDateTimeColumn() : base(new DataGridViewDateTimeCell())
        {
            base.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            base.SortMode = DataGridViewColumnSortMode.Automatic;
        }
        public DataGridViewDateTimeColumn(Object defaultNewRowValue) : base(new DataGridViewDateTimeCell(defaultNewRowValue))
        {
            // Does nothing
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a DataGridViewDateTimeCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewDateTimeCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewDateTimeCell");
                }
                base.CellTemplate = value;
            }
        }
    }
