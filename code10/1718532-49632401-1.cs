    public int MultiplyFoo(int id)
    {
        __MultiplyFoo__Variables variables = new __MultiplyFoo__Variables();
        variables.id = id;
        return __Generated__LocalBar(ref variables);
    }
    private struct __MultiplyFoo__Variables
    {
        public int id;
    }
    private int __Generated__LocalBar(ref __MultiplyFoo__Variables variables)
    {
        return variables.id * 2;
    }
