    var result = new List();            
    VisualTreeHelper.HitTest(
        myUiElement,
        null,
        new HitTestResultCallback(
            (HitTestResult hit)=>{ result.Add(hit.VisualHit); }),
        new PointHitTestParameters(myPoint));
