csharp
public class Extensions
{
  public static bool Any(this IEnumerable source)
  {
    if (source == null) throw ArgumentNullException(nameof(source));
    // Performance tweak to eliminate allocation of enumerator if we have a count.
    if (source is ICollection) return ((ICollection)source).Count > 0;
    IEnumerator e = source.GetEnumerator();
    bool any = e.MoveNext();
    // Make sure the enumerator is properly disposed of if necessary.
    // IEnumerator<T> implements IDisposable but an implementation of IEnumerator itself might.
    if (e is IDisposable) ((IDisposable)e).Dispose();
    return any;
  }
}
