    public float nearMountainMoveSpeed = 1f;
    public float farMountainMoveSpeed = 0.1f;
    . . .
    public void MoveMountains(float cameraMoveAmount) {
        float nearMountainParallaxMove = nearMountainMoveSpeed * -cameraMoveAmount;
        float farMountainParallaxMove = farMountainMoveSpeed * -cameraMoveAmount;
        MountainNearXPosition += nearMountainParallaxMove;
        foreach (GameObject nearMountain in pooledNearMountains) {
            nearMountain.transform.position = nearMountain.transform.position + new Vector3(nearMountainParallaxMove,0f,0f);
        }    
 
        MountainFarXPosition += farMountainParallaxMove;
        foreach (GameObject farMountain in pooledFarMountains) {
            farMountain.transform.position = nearMountain.transform.position + new Vector3(nearMountainParallaxMove,0f,0f);
    }
 
