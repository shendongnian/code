/// <summary>
///     Gets <see cref="System.Random"/> instance.
/// </summary>
public static Random Random { get; } = new Random(Guid.NewGuid().GetHashCode());
    
/// <summary>
///     Gets random combination of Flags Enum.
/// </summary>
/// <typeparam name="T">Enum type.</typeparam>
/// <returns>Random Flags Enum combination.</returns>
public static T GetRandomFlagsEnumValue<T>()
    where T : Enum
{
    var allValues = (T[])Enum.GetValues(typeof(T));
    ulong numberValue = allValues.OrderBy(x => Random.Next())
        .Take(GetRandomInteger(1, allValues.Length - 1))
        .Select(e => Convert.ToUInt64(e, CultureInfo.InvariantCulture))
        .Aggregate((a, c) => a + c);
    return (T)Enum.ToObject(typeof(T), numberValue);
}
