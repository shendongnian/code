c#
public static T Sum(T[] items)
{
    T sum = Number.Zero<T>();
    foreach (T item in items)
    {
        sum = Number.Add(sum, item);
    }
    return sum;
}
c#
public static T SumAlt(T[] items)
{
    // implicit conversion to Number<T>
    Number<T> sum = Number.Zero<T>();
    foreach (T item in items)
    {
        // operator support
        sum += item;
    }
    // implicit conversion to T
    return sum;
}
  [1]: https://github.com/TylerBrinkley/Genumerics
