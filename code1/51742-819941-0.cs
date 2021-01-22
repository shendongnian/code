    public class MyGameObject : Game, IGame
    {
        //you can leave this empty since you are inheriting from Game.    
    }
    public IGame
    {
        public GameComponentCollection Components { get; set; }
        public ContentManager Content { get; set; }
        //etc...
    }
