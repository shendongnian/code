public delegate void SomeMethod(params Company[] parameters);
public TimeSpan BenchmarkMethod(SomeMethod someMethod, params Company[] parameters) {
    DateTime benchmarkStart = DateTime.Now;
    someMethod(parameters);
    DateTime benchmarkFinish = DateTime.Now;
    return benchmarkFinish - benchmarkStart;
}
public void InsertObjects(object c) {
    Console.WriteLine(c);
}
