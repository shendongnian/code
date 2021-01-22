    public class Foo
    {
        private readonly Subject<string> _doValues = new Subject<string>();
        public IObservable<string> DoValues { get { return _doValues; } }
        public string Do(int param)
        {
            var ret = (param * 2).ToString();
            _doValues.OnNext(ret);
            return ret;
        }
    }
    var foo = new Foo();
    foo.DoValues.Subscribe(Console.WriteLine);
    foo.Do(2);
