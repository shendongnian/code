    public IEnumerable<Color> GetGradients(Color start, Color end, int steps)
    {
        Color stepper = Color.FromArgb((byte)((end.A - start.A) / (steps - 1)),
                                       (byte)((end.R - start.R) / (steps - 1)),
                                       (byte)((end.G - start.G) / (steps - 1)),
                                       (byte)((end.B - start.B) / (steps - 1)));
        for (int i = 0; i < steps; i++)
        {
            yield return Color.FromArgb(start.A + (stepper.A * i),
                                        start.R + (stepper.R * i),
                                        start.G + (stepper.G * i),
                                        start.B + (stepper.B * i));
        }
    }
