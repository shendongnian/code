internal interface ISecretInterface
{
    string Property1 { get; }
}
public class PublicClass : ISecretInterface
{
    // class property
    public string Property1
    {
        get { return "Foo"; }
    }
    // interface property
    string ISecretInterface.Property1
    {
        get { return "Secret"; }
    }
}
