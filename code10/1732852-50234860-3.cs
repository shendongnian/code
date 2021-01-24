    public class CameraManager
    {
        public void UpdateGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Intro:
                    // do stuff
                    break;
                case GameState.Tutorial:
                    MoveToTutorialPosition();
                    break;
                case GameState.GamePlay:
                    // do stuff
                    break;
            }
        }
    }
    
    public class SoundManager
    {
        public void UpdateGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Intro:
                    // do stuff
                    // break;
                case GameState.Tutorial:
                    PlayTutorialAudio();
                    break;
                case GameState.GamePlay:
                    // do stuff
                    // break;
            }
        }
    }
