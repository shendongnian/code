    public abstract class Machine<S,M> where S : State<S,M> where M : Machine<S,M>  {
        protected S state;
    }
     
    public abstract class State<S,M> where S : State<S,M> where M : Machine<S,M> {
        protected M machine;
    }
