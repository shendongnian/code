    class MyResult
    {
        public int[] Array { get; set; }
        public int Integer { get; set; }
    }
    ...
    private MyResult FunctionName(int[] inputArray)
    {
        return new MyResult { Array = ..., Integer = ... };
    }
