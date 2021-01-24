    using System.Linq;
    using System.Numerics;
    ...
    // Slow, ugly but easy to understand and check routine
    static int naiveCount(int value) {
      BigInteger factorial = 1;
      for (int i = 1; i <= value; ++i)
        factorial *= i;
      return factorial.ToString().Length - factorial.ToString().TrimEnd('0').Length;
    }
    ...
    var counterExamples = Enumerable
      .Range(0, 100)
      .Select(v => new {
         value = v,
         actual = calculateFact(v),
         expected = naiveCount(v), })
      .Where(item => item.expected != item.actual)
      .Select(item => $"value: {item.value,4} actual: {item.actual,3} expected: {item.expected,3}");
    Console.Write(string.Join(Environment.NewLine, counterExamples));
