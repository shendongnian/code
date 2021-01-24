    public float maxAngleRotatePerFrame = 5f;
    void FixedUpdate(){
        if(shouldUpdate) { //set to true for a success response from the api call
            // Keep track of how far we've traveled in this frame.
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
    
                // Update how much we've rotated already. This determines
                // if we get to go through the while loop again.
                angleTraveledThisFrame += curAngleRotate;
    
                if (angleTraveledThisFrame < maxAngleRotatePerFrame ) {  
                    // If we have more rotating to do this frame,
                    // increment the index.
                    ind++;
                    if (ind==dataLen) {
                        // If you need to do anything when you run out of rotations, 
                        // you can do it here.
                    }
                }
            }
        }
    }
