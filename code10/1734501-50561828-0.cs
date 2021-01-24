    private void btnmain_Click(object sender, RoutedEventArgs e)
    {
        _visualA.Offset = new System.Numerics.Vector3(400, 350, 350);
    }
    private void btntest_Click(object sender, RoutedEventArgs e)
    {
        _visualA = ElementCompositionPreview.GetElementVisual(btnmain);
        _visualB = ElementCompositionPreview.GetElementVisual(pop); 
        compositor = _visualB.Compositor; 
        var expression = compositor.CreateExpressionAnimation("visualA.Offset.X + 50");
        expression.SetReferenceParameter("visualA", _visualA);
        _visualB.StartAnimation("Offset.X", expression);
    }
