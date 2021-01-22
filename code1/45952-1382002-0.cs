static void Main(string[] args)
{
  var domain = "matrix";
  Check(() => domain);
  Console.ReadLine();
}
static void Check<T>(Expression<Func<T>> expr)
{
  var body = ((MemberExpression)expr.Body);
  Console.WriteLine("Name is: {0}", body.Member.Name);
  Console.WriteLine("Value is: {0}", ((FieldInfo)body.Member)
   .GetValue(((ConstantExpression)body.Expression).Value));
}
// Output will be:
// Name is: 'domain'
// Value is: 'matrix'
