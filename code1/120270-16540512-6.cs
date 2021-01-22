    var result = new List<DependencyObject>(); 
                             //changed from external edits, because VisualHit is
                             //only a DependencyObject and may not be a UIElement
                             //this could cause exceptions or may not be compiling at all
    VisualTreeHelper.HitTest(
        myUiElement,
        null,
        new HitTestResultCallback(
            (HitTestResult hit)=>{
                result.Add(hit.VisualHit);
                return HitTestResultBehavior.Continue;
            }),
        new PointHitTestParameters(myPoint));
