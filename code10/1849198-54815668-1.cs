var allAreZero = new string[] { "  0  ", "  0", "  0" };
var allAreOne = new string[] { "  1  ", "1", "  1" };
var mixedOnesAndZeros = new string[] { "  1  ", "0", "  1" };
private bool ArrayIsExclusivelyTrueOrFalse(string[] data)
{
    return data.All(i => int.TryParse(i, out int value) && value == 0) ||
           data.All(i => int.TryParse(i, out int value) && value == 1);
}
ArrayIsExclusivelyTrueOrFalse(allAreZero);          // true
ArrayIsExclusivelyTrueOrFalse(allAreOne);           // true
ArrayIsExclusivelyTrueOrFalse(mixedOnesAndZeros);   // false
