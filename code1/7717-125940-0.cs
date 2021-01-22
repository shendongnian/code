public void FooCommand()
{
    Future&lt;int&gt; BarFuture = new Future&lt;int&gt;( () => BarCommand() );
    // Do Foo's Processing - Bar will (may) be running in parallel
    int barResult = BarFuture.Value;
    // More processing that needs barResult
}
