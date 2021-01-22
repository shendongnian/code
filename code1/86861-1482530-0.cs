	public class PaintAccommodatingTextBoxCell : DataGridViewTextBoxCell
	{
		// Adjust the editing panel, so that custom painting isn't
		// drawn over when cells go into edit mode.
		public override Rectangle PositionEditingPanel(Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
		{
			// First, let base class do its adjustments
			Rectangle controlBounds = base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
			
			// Shrink the bounds here...
			
			return controlBounds;
		}
	}
	public class PaintAccommodatingTextBoxColumn : DataGridViewTextBoxColumn
	{
		PaintAccommodatingTextBoxCell templateCell;
		public PaintAccommodatingTextBoxColumn()
		{
			templateCell = new PaintAccommodatingTextBoxCell();
		}
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return templateCell;
			}
			set
			{
				PaintAccommodatingTextBoxCell newTemplate = value as PaintAccommodatingTextBoxCell;
				if (newTemplate == null)
					throw new ArgumentException("Template must be a PaintAccommodatingTextBoxCell");
				else
					templateCell = newTemplate;
			}
		}
	}
