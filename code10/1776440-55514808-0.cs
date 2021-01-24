c#
public class BarConsumerFactoryConverter : DefaultTypedFactoryComponentSelector
{
    private IFillangie _fillangie;
    public BarConsumerFactoryConverter(IFillangie fillangie)
    {
        _fillangie = fillangie;
    }
    protected override Arguments GetArguments(MethodInfo method, object[] arguments)
    {
        if (arguments == null)
            return null;
        Arguments argumentMap = new Arguments();
        ParameterInfo[] parameters = method.GetParameters();
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i].ParameterType == typeof(Test))
                argumentMap.Add(typeof(IEnumerable<IBar>), _fillangie.FinalStep((Test) arguments[i]));
            else
                argumentMap.Add(parameters[i].Name, arguments[i]);
        }
        return argumentMap;
    }
}
This `BarConsumerFactoryConverter` has to be registered with your `IWindsorContainer` as well:
c#
container.Register(Component.For<BarConsumerFactoryConverter, ITypedFactoryComponentSelector>());
Finally you have to tell your factory to use `BarConsumerFactoryConverter` as its component selector:
c#
container.Register(Component.For<IBarConsumerFactory>().AsFactory(f => f.SelectedWith<BarConsumerFactoryConverter>()));
  [1]: https://stackoverflow.com/a/52212457/6695901
