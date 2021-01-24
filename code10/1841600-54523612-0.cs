    if(GUILayout.Button("Main Menu"))
    {   
        if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            // user said yes -> scene was saved
            EditorSceneManager.OpenScene("Assets/_Scenes/00MainMenu.unity");
        }
        else
        {
            // user said no or there was an error -> evtl. abort or do nothing?
        }
    }
    if(GUILayout.Button("Level01"))
    {
        if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            // // user said yes -> scene was saved
            EditorSceneManager.OpenScene("Assets/_Scenes/01Level.unity");
        }
        else
        {
            // user said no or there was an error -> evtl. abort or do nothing?
        }
    }
    
