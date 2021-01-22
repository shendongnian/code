using System;<BR>
public class Program<BR>
{<BR>
    public static bool IsGuid(object item)<BR>
    {
        return item is Guid;<BR>
    } <BR>
<BR>
    public static void Main()<BR>
    { <BR>
        Guid s = Guid.NewGuid();<BR>
        Console.Write(IsGuid(s));<BR>
    }<BR>
}<BR>
