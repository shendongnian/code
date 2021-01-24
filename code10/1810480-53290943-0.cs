    public float maxAngleRotatePerFrame = 5f;
    void FixedUpdate(){
        if(shouldUpdate) { //set to true for a success response from the api call
            float angleTraveledThisFrame = 0f;
            
            // Rotate until we've rotated as much as we can in a single frame, 
            // or we run out of rotations to do.
            while (angleTraveledThisFrame < maxAngleRotatePerFrame && ind < dataLen) {
                // Figure out how we want to rotate and how much that is
                Quaternion curRot = transform.rotation;
                Quaternion goalRot = Quaternion.Euler(
                        batData.x[ind],
                        batData.y[ind],
                        batData.z[ind]
                        );
                float angleLeftInThisInd =  Quaternion.Angle(curRot, goalRot);
     
                // Rotate as much as we can toward that rotation this frame
                float curAngleRotate = Mathf.Min(
                        angleLeftInThisInd, 
                        maxAngleRotatePerFrame - angleTraveledThisFrame
                        );
    
                transform.rotation = Quaternion.RotateTowards(curRot, goalRot, curAngleRotate);
    
                // Keep track of how much we've rotated already, 
                // in case we need to get another rotation in our queue.
                angleTraveledThisFrame += curAngleRotate;
    
                if (curAngleRotate == angleLeftInThisInd) {  
                    // If we could rotate all the way to the goal rotation,
                    // set up the next one in the queue.
                    ind++;
                    if (ind==dataLen) {
                        // If you need to do anything when you run out of rotations, 
                        // you can do it here.
                    }
                }
            }
        }
    }
