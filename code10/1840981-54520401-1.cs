    [MenuItem("MyMenu/DevTools/ResetPlayer #r")]
    private static void ResetPlayer()
    {
        var player = GameObject.Find("Player");                                     // Find Player GameObject.
        Transform playerPos = player.GetComponent<Transform>();                     // Get the Transform from PlayerGO and make it to a Transform playerPos.
        //Vector3 resets = new Vector3(-7, 0, 0);                                    // Define the hardcoded position you want to reset the player to.                              
        
        playerPos.position = resets;                                                // Set playerPos to a hardcoded position.
    }
