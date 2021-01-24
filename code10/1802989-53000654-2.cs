      public class CaptureResultScrollViewDelegate : UIScrollViewDelegate
        {
            public CaptureResultScrollViewDelegate(IHandlePaging pageHandler)
            {
                this.pageHandler = pageHandler ?? throw new ArgumentNullException(nameof(pageHandler));
            }
    
            private readonly IHandlePaging pageHandler;
    
            public override UIView ViewForZoomingInScrollView(UIScrollView scrollView)
            {
                var pageIndex = (int)Math.Round(scrollView.ContentOffset.X / scrollView.Frame.Size.Width);
                return pageHandler.backView;
    
            }
        }
