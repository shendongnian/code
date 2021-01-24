    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace wpf_99
    {
    public class NoClipStackPanel : StackPanel
    {
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            return ClipToBounds ? base.GetLayoutClip(layoutSlotSize) : null;
        }
        }
    }
