    var builder = ImmutableArray.CreateBuilder<int>(4);
    builder.Add(1);
    builder.Add(2);
    builder.Add(3);
    builder.Add(4);
    ImmutableArray<int> array = builder.MoveToImmutable();
