    class Foo{ 
        ...
        public Foo 
            Set
            ( double? majorBar=null
            , double? minorBar=null
            , int?        cats=null
            , double?     dogs=null)
        {
            return new Foo
                ( majorBar ?? MajorBar
                , minorBar ?? MinorBar
                , cats     ?? Cats
                , dogs     ?? Dogs);
        }
        public Foo
            ( double R
            , double r
            , int l
            , double e
            ) 
        {
            ....
        }
    }
