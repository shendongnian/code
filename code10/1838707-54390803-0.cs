    public class Level
        {
            PhysicsManager physics;
            
            public Level()
            {
                physics = new PhysicsManager();
            }
    
            public void AddPlayer(Player Player)
            {
                physics.AddMesh(Player.Mesh);
            }
        }
