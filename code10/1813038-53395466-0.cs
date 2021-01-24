    var model= new PlotModel();
    model.MouseDown += Model_MouseDown;
    
    private void Model_MouseDown(object sender, OxyMouseDownEventArgs e)
    {
        var controller = sender as PlotController;
        var position = e.HitTestResult;
    }
