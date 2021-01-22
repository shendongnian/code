    public class Foo
    {
       public string Bar1
       {
          get{return this._Bar1;}
          set{this.SafeSet(ref this._Bar1, value);}
       }public string _Bar1;
    
       public int Bar2
       {
          get{return this._Bar2;}
          set{this.SafeSet(ref this._Bar2, value);}
       }public int _Bar2;
    
       protected virtual SafeSet<T> (ref T local, T val)
       {
          if(local != val)
          {
             local = val;
             //whatever other post-processing you want
          }
       }
    }
