csharp
foreach (var permutation in "abc".Permutations())
{
	Console.WriteLine(string.Join(", ", permutation));
}
Outputs:
a, b, c
a, c, b
b, a, c
b, c, a
c, b, a
c, a, b
Or on any other collection type:
csharp
foreach (var permutation in (new[] { "Apples", "Oranges", "Pears"}).Permutations())
{
	Console.WriteLine(string.Join(", ", permutation));
}
Outputs:
Apples, Oranges, Pears
Apples, Pears, Oranges
Oranges, Apples, Pears
Oranges, Pears, Apples
Pears, Oranges, Apples
Pears, Apples, Oranges
csharp
using System;
using System.Collections.Generic;
using System.Linq;
public static class PermutationExtension
{
	public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> source)
	{
		var sourceArray = source.ToArray();
		var results = new List<T[]>();
		Permute(sourceArray, 0, sourceArray.Length - 1, results);
		return results;
	}
	private static void Swap<T>(ref T a, ref T b)
	{
		T tmp = a;
		a = b;
		b = tmp;
	}
	private static void Permute<T>(T[] elements, int recursionDepth, int maxDepth, ICollection<T[]> results)
	{
		if (recursionDepth == maxDepth)
		{
			results.Add(elements.ToArray());
			return;
		}
		for (var i = recursionDepth; i <= maxDepth; i++)
		{
			Swap(ref elements[recursionDepth], ref elements[i]);
			Permute(elements, recursionDepth + 1, maxDepth, results);
			Swap(ref elements[recursionDepth], ref elements[i]);
		}
	}
}
