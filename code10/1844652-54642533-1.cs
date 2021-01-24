public static string GetDisplayName(Member member, string currency)
{
    return string.Join(" ", GetDisplayNameParts(member, currency));
}
public static IEnumerable<string> GetDisplayNameParts(Member member, string currency)
{
    switch (currency)
    {
        case "CND":
            yield return member.LastName ?? ""
            yield return member.FirstName ?? ""
            yield break;
        default:
            yield return member.FirstName ?? ""
            yield return member.LastName ?? ""
            yield break;
    }
}
