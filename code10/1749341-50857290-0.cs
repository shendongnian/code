    public class MyRequest
    {
        public string Str { get; set; }
    }
    [HttpPost]
    public void Foo(MyRequest request)
    {
        ...
    }
