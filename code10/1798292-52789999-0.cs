    private bool isIntermediate;
    private bool moveCamera;
    private void LateUpdate ()
    {
        if(!moveCamera) return;
        if(isIntermediate)
        {
            camera.lerp(intermediatePosition);
        } 
        else 
        {
            camera.lerp(positionToMoveTo);
        }     
    }
    private IEnumerator MoveCamera() 
    {
        moveCamera = true;
        isIntermediate=true;
        yield return new WaitForSeconds(3f);
        isIntermediate=false;
        // Wait until the camera reaches the target
        while(camera.transform.position == PositionToMoveTo){
            yield return null;
        }
        // Stop moving
        moveCamera = false;
        // just to be sure your camera has exact the correct position in the end
        camera.transform.position = PositionToMoveTo;
    }
