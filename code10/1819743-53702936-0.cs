    interface IEnemy
    {
        void FollowPlayer();
    }
    class EnemySniper : IEnemy
    {
        void FollowPlayer()
        {
            //Implement Followig Player Logic for Sniper
        }
    }
    class EnemyManager
    {
        List<IEnemy> enemies = new List<IEnemy>();
        //Add all your enemies at gamestart or wherever
        foreach(IEnemy ie in enemies) //this needs to be called on each Update()
            ie.FollowPlayer();
    }
