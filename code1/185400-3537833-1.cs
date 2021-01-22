    ArrayContainer container = new ArrayContainer();
    container.Array1 = new byte[] { 1 };
    container.Array2 = new byte[] { 2 };
    ArrayContainer copy = container.DeepCopy();
    copy.Array1[0] = 3;
    Console.WriteLine("{0}, {1}, {2}, {3}", container.Array1[0], container.Array2[0], copy.Array1[0], copy.Array2[0]);
