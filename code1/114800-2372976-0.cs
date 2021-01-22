    public partial class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            InitializeComponent();
        }
        public CustomDataGridView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        private bool _delayedMouseDown = false;
        private Rectangle _dragBoxFromMouseDown = Rectangle.Empty;
        private Func<object> _getDragData = null;
        public void EnableDragDrop(Func<object> getDragData)
        {
            _getDragData = getDragData;
        }
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseDown(e);
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                var currentRow = this.CurrentRow.Index;
                var selectedRows = this.SelectedRows.OfType<DataGridViewRow>().ToList();
                var clickedRowSelected = this.Rows[e.RowIndex].Selected;
                this.CurrentCell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Select previously selected rows, if control is down or the clicked row was already selected
                if ((Control.ModifierKeys & Keys.Control) != 0 || clickedRowSelected)
                    selectedRows.ForEach(row => row.Selected = true);
                // Select a range of new rows, if shift key is down
                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    for (int i = currentRow; i != e.RowIndex; i += Math.Sign(e.RowIndex - currentRow))
                        this.Rows[i].Selected = true;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            var rowIndex = base.HitTest(e.X, e.Y).RowIndex;
            _delayedMouseDown = (rowIndex >= 0 &&
                (SelectedRows.Contains(Rows[rowIndex]) || (ModifierKeys & Keys.Control) > 0));
            if (!_delayedMouseDown)
            {
                base.OnMouseDown(e);
                if (rowIndex >= 0)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;
                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    _dragBoxFromMouseDown = new Rectangle(
                        new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
                else
                    // Reset the rectangle if the mouse is not over an item in the datagridview.
                    _dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Perform the delayed mouse down before the mouse up
            if (_delayedMouseDown)
            {
                _delayedMouseDown = false;
                base.OnMouseDown(e);
            }
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // If the mouse moves outside the rectangle, start the drag.
            if (_getDragData != null && (e.Button & MouseButtons.Left) > 0 &&
                _dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
            {
                if (_delayedMouseDown)
                {
                    _delayedMouseDown = false;
                    if ((ModifierKeys & Keys.Control) > 0)
                        base.OnMouseDown(e);
                }
                // Proceed with the drag and drop, passing in the drag data
                var dragData = _getDragData();
                if (dragData != null)
                    this.DoDragDrop(dragData, DragDropEffects.Move);
            }
        }
    }
