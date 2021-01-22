    public class Foo
    {
        private int _bar = 5;
        [OnSerializing]
        public void OnSerializeFoo( StreamingContext context )
        {
            _bar = 10;
        }
    }
