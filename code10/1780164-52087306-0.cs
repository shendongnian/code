    using System.Data.SqlTypes;
    public static double GradualRoundingTo0(this double d) {
        var dp = ((SqlDecimal)(Decimal)d).Scale;
        return Enumerable.Range(1, dp).Aggregate(d, (a, n) => Math.Round(a, dp - n, MidpointRounding.AwayFromZero));
    }
