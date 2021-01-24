    // How fast the mountain layers are going to move in the direction of the camera.    
    // 0.0f - will not move with the camera, mountains will slide out of frame at normal speed.
    // 1.0f - will move with the camera, no movement will be visible in frame.
    public float nearMountainMoveSpeed = 0.5;
    public float farMountainMoveSpeed = 0.9f;
    . . .
    public void MoveMountains(float cameraMoveAmount) {
        float nearMountainParallaxMove = nearMountainMoveSpeed * cameraMoveAmount;
        float farMountainParallaxMove = farMountainMoveSpeed * cameraMoveAmount;
        // Move the near mountains & their next placement
        MountainNearXPosition += nearMountainParallaxMove;
        foreach (GameObject nearMountain in pooledNearMountains) {
            nearMountain.transform.position = nearMountain.transform.position + new Vector3(nearMountainParallaxMove,0f,0f);
        }    
 
        // Move the far mountains & their next placement
        MountainFarXPosition += farMountainParallaxMove;
        foreach (GameObject farMountain in pooledFarMountains) {
            farMountain.transform.position = farMountain.transform.position + new Vector3(farMountainParallaxMove,0f,0f);
        }
    }
 
