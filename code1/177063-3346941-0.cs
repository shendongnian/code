    class Enemy : Drawable, IEntity
    {
        public Enemy(int id) : base(id) { }
        public void Update(EnemyData data)
        { ... }
        void IUpdatetable<IData>.Update(IData data)
        {
            Update(data as EnemyData);
        }
    }
    class Player : Drawable, IEntity
    {
        public Player(int id) : base(id) { }
        public void Update(PlayerData data)
        { ... }
        void IUpdatetable<IData>.Update(IData data)
        {
            Update(data as PlayerData);
        }
    }
