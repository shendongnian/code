string TryGetEntry(string key, Funct&lt;problemCause, string&gt; errorHandler)
{
  if (disposed)
    return errorHandler(problemCause.ObjectDisposed);
  else if (...entry_doesnt_exist...)
    return errorHandler(problemCause.ObjectNotFound);
  else
    return ...entry...;
}
string GetEntry(string key)
{
  return TryGetEntry(key, ThrowExceptionOnError);
}
bool TryGetEntry(string key, ref result)
{
  bool ok;
  string result;
  result = TryGetEntry(key, (problemCause theProblem) => {ok=false; return (string)null;});
  return ok;
}
