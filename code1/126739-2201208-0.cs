Mutex m = new Mutex()
m.WaitOne();
try
{
  if(..)
    throw new Exception();              
}
finally
{
  // code in the finally will run regardless of whether and exception is thrown.
  m.ReleaseMutex();
}
