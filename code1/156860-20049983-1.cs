    public class Factory
    {
        public static ICovariantTuple<ISubModelInterface, ISubViewInterface> Build()
        {
        }
    }
    ICovariantTuple<IBaseModelInterface, IBaseViewInterface> result = Factory.Build();
