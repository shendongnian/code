/// <summary>
/// Some magic happens here: Find the correct action to take, by reflecting on types 
/// subclassed from IStep with that name.
/// </summary>
private IStep GetStep(string sName)
{
    Assembly assembly = Assembly.GetAssembly(typeof (IStep));
    try
    {
        return (IStep) (from t in assembly.GetTypes()
                        where t.Name == sName && t.GetInterface("IStep") != null
                        select t
                        ).First().GetConstructor(new Type[] {}
                        ).Invoke(new object[] {});
    }
    catch (InvalidOperationException e)
    {
        throw new ArgumentException("Action not supported: " + sName, e);
    }
}
