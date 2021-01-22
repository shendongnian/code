FIZZBUZZ.Switch(Fizz => DoSomething(),
                Buzz => DoSomethingElse(),
                FizzBuzz => DoSomethingElseStill());
Where Switch is an extension method:
public static void Switch(this string @this, params Expression&lt;Action>[] cases)
{
    Expression&lt;Action> matchingAction = cases.SingleOrDefault(@case => @case.Parameters[0].Name == @this);
    if (matchingAction == null) return; // no matching action
    matchingAction.Compile()();
}
