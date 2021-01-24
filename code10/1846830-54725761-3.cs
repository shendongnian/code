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
The problem, then appears to be the intermediate variable `ratio`, although it's more accurate to think of it as an order-of-operations problem. The addition of parentheses re-introduces the error from the original code...
csharp
[Fact]
public void AnotherModifiedFirstApproach()
{
    // Values from first approach,
    // but with intermediate variables removed
    decimal ratioAmount = 12.000m * (1m / 12m);
    Assert.Equal(0.9999999999999999999999999996m, ratioAmount);
}
The core problem can be illustrated in a single line...
csharp
[Fact]
public void OneTwelfthAsDecimal()
{
    Assert.Equal(0.0833333333333333333333333333m, 1m / 12m);
}
The fraction `1/12` can only be expressed as a repeating decimal, which makes it imprecise. This isn't C#'s fault--it's just a fact of working in a decimal (base-10) number system.
