csharp
[Fact]
public void FirstApproach()
{
    // First approach:    
    decimal ratio = 1m / 12m;
    decimal amount = 12.000m;
    decimal ratioAmount = amount * ratio;
    Assert.Equal(0.9999999999999999999999999996m, ratioAmount);
}
Clearly, `12 * (1/12)` should be `1`, so this _seems_ wrong.
With a slight modification, we can get the "correct" answer...
csharp
[Fact]
public void ModifiedFirstApproach()
{
    // Values from first approach,
    // but with intermediate variables removed
    decimal ratioAmount = 12.000m * 1m / 12m;
    Assert.Equal(1.000m, ratioAmount);
}
The problem, then is the intermediate variable `ratio`. Another example illustrates why it's a problem...
csharp
[Fact]
public void OneTwelfthAsDecimal()
{
    var oneTwelfth = 1m / 12m;
    Assert.Equal(0.0833333333333333333333333333m, oneTwelfth);
}
The number `1/12` can only be expressed as a repeating decimal, which makes it imprecise. This isn't C#'s fault--it's just a fact of working in a base-10 number system.
