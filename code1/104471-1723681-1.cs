    bstract class  B<T> {
       public abstract T Fct(T t);
    }
    class D1 : B<string>{
       public override string Fct( string t ) { return "hello"; }
    }
    class D2<T> : B<T>{
       public override T Fct(T t) { return default (T); }
    }
