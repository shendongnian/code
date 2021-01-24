`
public interface IRequest<T> where T : IResponse
{
    Type GetResponseType();
}
public interface IResponse { }
public class Res : IResponse
{
    public string response { get; set; }
}
public class Req : IRequest<Res>
{
    public string request { get; set; }
    public Type GetResponseType()
    {
        return typeof(Res);
    }
}
`
