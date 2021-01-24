     if (health == 0)
        {
          switch(SceneManager.GetActiveScene()){
           case SceneManager.GetSceneByName("Level 2 - Damages"):
                SceneManager.LoadScene("Gameover 1");
                break;
           case default: 
                 SceneManager.LoadScene("MainMenu");
            }
        } 
