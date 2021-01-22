<pre>
public static IList&lt;HashSet&lt;T&gt;&gt; Partition&lt;T>(this IEnumerable&lt;T> input, Func&lt;T, object> partitionFunc)
{
      Dictionary&lt;object, HashSet<T>> partitions = new Dictionary&lt;object, HashSet&lt;T>>();
      object currentKey = null;
      foreach (T item in input ?? Enumerable.Empty<T>())
      {
          currentKey = partitionFunc(item);
          if (!partitions.ContainsKey(currentKey))
          {
              partitions[currentKey] = new HashSet<T>();
          }
          partitions[currentKey].Add(item);
      }
      return partitions.Values.ToList();
}
</pre>
