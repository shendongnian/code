class Car&lt;T&gt;
{ }
interface IVehicle { }
class YourCar : Car&lt;int&gt;, IVehicle
{ }
static bool IsOfType(IVehicle param)
{
    Type typeRef = param.GetType();
    while (typeRef != null)
    {
        if (typeRef.IsGenericType &&
            typeRef.GetGenericTypeDefinition() == typeof(Car&lt;&gt;))
        {
            return true;
        }
        typeRef = typeRef.BaseType;
    }
    return false;
}
static void Main(string[] args)
{
    IVehicle test = new YourCar();
    bool x = IsOfType(test);
}
</pre>
