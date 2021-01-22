    [ContentProperty("Child")]
    [DefaultEvent("Opened")]
    [DefaultProperty("Child")]
    [Localizability(LocalizationCategory.None)]
    public class DraggablePopup : Popup
    {
        public DraggablePopup()
        {
            MouseDown += (sender, e) =>
            {
                Thumb.RaiseEvent(e);
            };
            Thumb.DragDelta += (sender, e) =>
            {
                HorizontalOffset += e.HorizontalChange;
                VerticalOffset += e.VerticalChange;
            };
        }
        /// <summary>
        /// The original child added via Xaml
        /// </summary>
        public UIElement TrueChild { get; private set; }
        public Thumb Thumb { get; private set; } = new Thumb
        {
            Width = 0,
            Height = 0,
        };
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            TrueChild = Child;
            var surrogateChild = new StackPanel();
            RemoveLogicalChild(TrueChild);
            surrogateChild.Children.Add(Thumb);
            surrogateChild.Children.Add(TrueChild);
            AddLogicalChild(surrogateChild);
            Child = surrogateChild;
        }
    }
