    class Foo
    {
        ... as above ...
        
        public void SetAGivenC( double newC )
        {
            A = newC/B;
        }
        public void SetBGivenC( double newC )
        {
            B = newC/A;
        }
    }
