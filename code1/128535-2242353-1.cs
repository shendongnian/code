public void Main()
{
    MethodQueue(MethodOne);
} 
public void MethodOne(int x, int y) 
{
    // do stuff
}
public void MethodQueue(Action<<int>int, int> method)
{
    // wait
    method(0, 0);
}
</pre>
