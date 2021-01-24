c#
public class TrimmedStringHandler : SqlMapper.TypeHandler<string>
{
    public override string Parse(object value)
    {
        string result = (value as string)?.Trim();
        return result;
    }
    public override void SetValue(IDbDataParameter parameter, string value)
    {
        parameter.Value = value;
    }
}
On the program initialization you must call the AddTypeHandler method of the SqlMapper class like bellow:
c#
SqlMapper.AddTypeHandler(new TrimmedStringHandler());
If you do this, every string that come from database will be trimmed.
