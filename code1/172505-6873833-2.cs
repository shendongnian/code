        protected override void OnMouseMove(MouseEventArgs mea) {
            if (Drag.IsDragging(mea)) {
                Drag.StartDragging(this);
                DragDropEffects dde = DoDragDrop(Plan, DragDropEffects.Move | DragDropEffects.Copy);
                Drag.StopDragging();
            }
        }
