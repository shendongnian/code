    public class DrawingSurface : Control {
        private Stack<DrawingContext> UndoBuffer = new Stack<DrawingContext>();
        private Stack<DrawingContext> RedoBuffer = new Stack<DrawingContext>();
        public DrawingSurface() {
            DoubleBuffered = true;
            CurrentDrawingContext = new DrawingContext();
            UndoBuffer.Push(currentDrawingContext.Clone());
        }
        DrawingContext currentDrawingContext;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DrawingContext CurrentDrawingContext {
            get {
                return currentDrawingContext;
            }
            set {
                if (currentDrawingContext != null)
                    currentDrawingContext.PropertyChanged -= CurrentDrawingContext_PropertyChanged;
                currentDrawingContext = value;
                Invalidate();
                currentDrawingContext.PropertyChanged += CurrentDrawingContext_PropertyChanged;
            }
        }
        private void CurrentDrawingContext_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            UndoBuffer.Push(CurrentDrawingContext.Clone());
            RedoBuffer.Clear();
            Invalidate();
        }
        public void Undo() {
            if (CanUndo) {
                RedoBuffer.Push(UndoBuffer.Pop());
                CurrentDrawingContext = UndoBuffer.Peek().Clone();
            }
        }
        public void Redo() {
            if (CanRedo) {
                CurrentDrawingContext = RedoBuffer.Pop();
                UndoBuffer.Push(CurrentDrawingContext.Clone());
            }
        }
        public bool CanUndo {
            get { return UndoBuffer.Count > 1; }
        }
        public bool CanRedo {
            get { return RedoBuffer.Count > 0; }
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(CurrentDrawingContext.BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            foreach (var shape in CurrentDrawingContext.Shapes)
                shape.Draw(e.Graphics);
        }
    }
