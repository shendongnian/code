 lang-cs
public static IEnumerable<Color> GetColorGradient(Color from, Color to, int totalNumberOfColors)
{
    if (totalNumberOfColors < 2)
    {
        throw new ArgumentException("Gradient cannot have less than two colors.", nameof(totalNumberOfColors));
    }
    
    double diffA = to.A - from.A;
    double diffR = to.R - from.R;
    double diffG = to.G - from.G;
    double diffB = to.B - from.B;
    
    var steps = totalNumberOfColors - 1;
    
    var stepA = diffA / steps;
    var stepR = diffR / steps;
    var stepG = diffG / steps;
    var stepB = diffB / steps;
    yield return from;
    for (var i = 1; i < steps; ++i)
    {
        yield return Color.FromArgb(
            c(from.A, stepA),
            c(from.R, stepR),
            c(from.G, stepG),
            c(from.B, stepB));
        int c(int fromC, double stepC)
        {
            return (int)Math.Round(fromC + stepC * i);
        }
    }
    
    yield return to;
}
[step-by-int]: https://stackoverflow.com/a/14246328/402749
