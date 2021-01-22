    enum opacityLevel { Min, Default, Max }
    private static readonly Dictionary<opacityLevel, float> _oLevels = new Dictionary<opacityLevel, float>
    {
        { opacityLevel.Max, 40.0 },
        { opacityLevel.Default, 50.0 },
        { opacityLevel.Min, 100.0 }
    };
    
    //Access float value like this
    var x = _oLevels[opacitylevel.Default];
