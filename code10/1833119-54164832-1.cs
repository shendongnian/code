c#
public CustomException(string paramName = "defaultName") : this(paramName, null)
{
}
public CustomException(string paramName = "defaultName", string message = "defaultMessage") : base(paramName, message)
{
}
