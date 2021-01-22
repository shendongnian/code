`cs
public class MyPath    
{
    public static string ForceCombine(params string[] paths)
    {
        return paths.Aggregate((x, y) => Path.Combine(x, y.Replace("\\", "")));
    }
}
`
