    string[][] lines = File.ReadAllLines(fileName)
      .Select(line => line.Split(' ')).ToArray();
    if (lines[0].Length != 2)
      throw new SomeException();
    int width = int.Parse(lines[0][0]);
    int height = int.Parse(lines[0][1]);
    int[][] matrix = lines.Skip(1)
      .Select(line => line.Select(n => int.Parse(n)).ToArray())
      .ToArray();
    if (matrix.Length != height || matrix.Any(line => line.Length != width))
      throw new SomeException();
