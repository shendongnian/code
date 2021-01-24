    LineType lineType = LineType.Straight;
    
    void Update()
    {
        if (lineType == LineType.Straight)
        {
            StraightLineTrack();
        }
        else if (lineType == LineType.Curve)
        {
            AnimationCurve();
        }
    }
