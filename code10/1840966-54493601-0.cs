    gazeButtonControl1 = GazeInput.GetGazeElement(GazeBlock1);
    if (gazeButtonControl1 == null)
    {
      gazeButtonControl1 = new GazeElement();
      GazeInput.SetGazeElement(GazeBlock1, gazeButtonControl1);
    }
