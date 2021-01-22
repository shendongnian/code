        public void TestCode()
        {
            Player p1 = new Player(100);
            Enemy e1 = new Enemy(1);
            PlayerData p1data = new PlayerData(11, "joe");
            EnemyData e1data = new EnemyData(12, 1000);
            DataHolder<Player, PlayerData> bag1 
                = new DataHolder<Player, PlayerData>(p1, p1data);
            DataHolder<Enemy, EnemyData> bag2 
                = new DataHolder<Enemy, EnemyData>(e1, e1data);
            Dictionary<int, IDataHolder> list = new Dictionary<int, IDataHolder>();
            list.Add(p1.ID, bag1);
            list.Add(e1.ID, bag2);
            foreach (int id in list.Keys )
            {
                IDataHolder item = list[id];
                if (item.Entity is Player)
                {
                    Player player = item.Entity as Player;
                    PlayerData pdata = item.Data as PlayerData;
                    Console.WriteLine("ID={0} PlayerName={1} DataId={2}", 
                        player.ID, pdata.Name, pdata.ID);
                }
                else if (item.Entity is Enemy)
                {
                    Enemy enemy = item.Entity as Enemy;
                    EnemyData edata = item.Data as EnemyData;
                    Console.WriteLine("ID={0} EnemyDamage={1} DataId={2}", 
                        enemy.ID, edata.Damage, edata.ID);
                }
            }
        }
