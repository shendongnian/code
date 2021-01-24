try
{
  DoThingThatFails();
}
catch (ExpectedException ex)
{
  LogException(ex, DateTime.Now);
  //rethrow the exception
  throw;
}
**Building a Library**
This could be an internal or public library. Exceptions are a great way to handle incorrect or unsupported operations. Say you have a class that needs to take a string. It absolutely needs to have a valid, non-null string passed to it. If the user of the Library (could be you or someone else) passes in an invalid value, like `null`, you can throw an exception.
Example:
class Example
{
  //name must be a valid, non-empty string
  public Example(string name)
  {
    if (String.IsNullOrEmpty(name))
      throw new InvalidOperationException("The name parameter was null or empty");
    //Initialize your new object
  }
}
