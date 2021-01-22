struct Foo
{
  public int x;
}
public unsafe static void Main()
{
  byte[] x = new byte[] { 1, 1, 0, 0 };
  Foo f;
  fixed (byte* xPtr = x)
  {
	f = *((Fpp*)xPtr);
  }
  Console.WriteLine(f.x);
}
