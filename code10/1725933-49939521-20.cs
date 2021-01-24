    var oldni = chart.Images.FindByName("marker");
    if (oldni != null)
    {
        oldni.Image.Dispose();
        chart.Images.Remove(oldni);
        oldni.Dispose();
    }
