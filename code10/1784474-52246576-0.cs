    interface IState{...}
    class Approved : IState {...}
    class Requested : IState {...}
    class Entity{
       public IState State {get; set;}
    }
