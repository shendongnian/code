    public Question(Post P) : base(p) {...}
        
    class Post 
    {
        public Post(Post P)
        {
             populate(P.ID);
        }
    
        void populate(int ID)
        {
             // load from DB, or however it happens
        }
    }
