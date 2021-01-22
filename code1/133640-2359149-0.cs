    public class FooStub: IFoo
    {
        event PropertyChangedEventHandler PropertyChanged;
        int _bar;
        public int Bar
        {
           set
           {
               if( PropertyChanged != null )
                   PropertyChanged();
               _bar = value;
           }
           get
           {
              return _bar;
           }
        }
    }
