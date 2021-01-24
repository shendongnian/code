    public class Scene3
    {
        void Start()
        {
            GameVariables.Instance.PlayerStates.Add(3, new PlayerState());
        }
        void Update() 
        {
            //Get player state for scene 1
            PlayerState playerStateScene1 = GameVariables.Instance.PlayerStates[1];
            //Get player state for scene 2
            PlayerState playerStateScene2 = GameVariables.Instance.PlayerStates[2];
            //Update player state for this scene
            GameVariables.Instance.PlayerStates[3].PlayerHealth = 80;
            GameVariables.Instance.PlayerStates[3].TotalScore += 100;
            [...]
        }
    }
