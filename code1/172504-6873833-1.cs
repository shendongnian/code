        public static void StartDragging(Control c) {
            Dragged = c;
            DisposeOldCursors();
            Bitmap bm = CursorUtil.AsBitmap(c);
            DragCursorMove = CursorUtil.CreateCursor((Bitmap)bm.Clone(), DragStart.X, DragStart.Y);      
            DragCursorLink = CursorUtil.CreateCursor((Bitmap)bm.Clone(), DragStart.X, DragStart.Y);      
            DragCursorCopy = CursorUtil.CreateCursor(CursorUtil.AddCopySymbol(bm), DragStart.X, DragStart.Y);
            DragCursorNo = CursorUtil.CreateCursor(CursorUtil.AddNoSymbol(bm), DragStart.X, DragStart.Y);
            //Debug.WriteLine("Starting drag");
        }   
        
        // This gets called once when we move over a new control,
        // or continuously if that control supports dropping.
        public static void UpdateCursor(object sender, GiveFeedbackEventArgs fea) {
            //Debug.WriteLine(MainForm.MousePosition);
            fea.UseDefaultCursors = false;
            //Debug.WriteLine("effect = " + fea.Effect);
            if (fea.Effect == DragDropEffects.Move) {
                Cursor.Current = DragCursorMove;
            } else if (fea.Effect == DragDropEffects.Copy) {
                Cursor.Current = DragCursorCopy;
            } else if (fea.Effect == DragDropEffects.None) {
                Cursor.Current = DragCursorNo;
            } else if (fea.Effect == DragDropEffects.Link) {
                Cursor.Current = DragCursorLink;
            } else {
                Cursor.Current = DragCursorMove;
            }
        }
        
