csharp
using static Enumerizer;
// prints: 0 1 2 3 4 5 6 7 8 9
foreach (int i in 0 <= i < 10)
    Console.Write(i + " ");
I also created a [proof of concept repository on GitHub](https://github.com/BrunoZell/Enumerizer) **with even more functionality** (reversed iteration, custom step size).
A minimal and very limited implementation of the above loop would look something like like this:
csharp
public readonly struct Enumerizer
{
    public static readonly Enumerizer i = default;
    public Enumerizer(int start) =>
        Start = start;
    public readonly int Start;
    public static Enumerizer operator <(int start, Enumerizer _) =>
        new Enumerizer(start);
    public static Enumerizer operator >(int _, Enumerizer __) =>
        throw new NotImplementedException();
    public static IEnumerable<int> operator <=(Enumerizer start, int end)
    {
        for (int i = start.Start; i < end; i++)
            yield return i;
    }
    public static IEnumerable<int> operator >=(Enumerizer _, int __) =>
        throw new NotImplementedException();
}
