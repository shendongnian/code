    public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
    {
        int stepA = ((end.A - start.A) / (steps - 1));
        int stepR = ((end.R - start.R) / (steps - 1));
        int stepG = ((end.G - start.G) / (steps - 1));
        int stepB = ((end.B - start.B) / (steps - 1));
        for (int i = 0; i < steps; i++)
        {
            yield return Color.FromArgb(start.A + (stepA * i),
                                        start.R + (stepR * i),
                                        start.G + (stepG * i),
                                        start.B + (stepB * i));
        }
    }
