    if (distanceFromTarget < 2f)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetFloat("Walking Speed", 0);
        }
        if (!endRot)
        {
            Quaternion goalRotation = Quaternion.Euler(0f,0f,0f);
            float angleToGoal = Quaternion.Angle(
                    goalRotation,
                    animators[0].transform.localRotation);         
            float angleThisFrame = Mathf.Min(angleToGoal, rotationSpeed * Time.deltaTime);   
    
            // use axis of Vector3.down to keep angles positive for ease of use
            animators[0].transform.Rotate(Vector3.down, angleThisFrame);
            animators[1].transform.Rotate(Vector3.up, angleThisFrame);
            // We end if we rotated the remaining amount.
            endRot = (angleThisFrame == angleToGoal);
        }
    }
