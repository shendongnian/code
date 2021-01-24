[CanBeNull]
public delegate string ReturnMaybeNull();
[NotNull]
public delegate string ReturnNotNull([NotNull]string someParam);
[NotNull]
private readonly ReturnMaybeNull FunctionThatMayReturnNull = () => null;
[NotNull]
private readonly ReturnNotNull FunctionThatNeverReturnsNull = someParam => null; // no warning
void Test()
{
    bool test = FunctionThatMayReturnNull().Equals(""); // no warning
    string thisStringIsNotNull = FunctionThatNeverReturnsNull(null); // parameter warning here
    if (thisStringIsNotNull == null) // no warning
    {
        test = test ^ true;
    }
}
