    interface IGrid {...}
    class Grid : IGrid { ...}
    class EditableGrid : IGrid { ... }
    
    abstract class AbstractGridMasterControl
    {
        protected IGrid Grid
        {
            set { this.panelControl.Controls.Add(value as Control);}
        }
    }
    
    class GridMasterConrol : AbstractGridMasterControl
    {
        public GridMasterControl()
        {
            this.Grid = new Grid();
        }
    }
    
    class EditableGridMasterConrol : AbstractGridMasterControl
    {
        public GridMasterControl()
        {
            this.Grid = new EditableGrid();
        }
    }
