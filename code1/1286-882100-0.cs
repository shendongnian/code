    int[] someArrayYouHaveAsInt;
    double[] copyOfArrayAsDouble = Array.ConvertAll<int, double>(
                                    someArrayYouHaveAsInt,
                                    new Converter<int,double>(
                                      delegate(int i) { return (double)i; }
                                    ));
