    var result = new List<UIElement>(); //edit: improved by James Robert Pattison
    VisualTreeHelper.HitTest(
        myUiElement,
        null,
        new HitTestResultCallback(
            (HitTestResult hit)=>{ 
                result.Add(hit.VisualHit);
                return HitTestResultBehavior.Continue;
            }),
        new PointHitTestParameters(myPoint));
