    public partial class DraggablePopup : Popup 
    {
        public DraggablePopup()
        {
            var thumb = new Thumb
            {
                Width = 0,
                Height = 0,
            };
            ContentCanvas.Children.Add(thumb);
            MouseDown += (sender, e) =>
            {
                thumb.RaiseEvent(e);
            };
            thumb.DragDelta += (sender, e) =>
            {
                HorizontalOffset += e.HorizontalChange;
                VerticalOffset += e.VerticalChange;
            };
        }
    }
