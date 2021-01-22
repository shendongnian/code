    private double[] _PatchSpectrum = new double[49]
    public double[] GetPatchSpectrum
    {
        get { return _PatchSpectrum; }
    }
    public double this[int index]
    {
        set { this._PatchSpectrum[index] = value; }
    }
