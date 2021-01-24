    public GameObject car;
    public List<Vector3> pos;
    bool isMoving = false;
    
    IEnumerator MoveCar()
    {
        //Loop over each postion
        for (int i = 0; i < pos.Count; i++)
        {   
            //Get next position
            Vector3 nextPosition = pos[i];
            //Move to new position within 1 second
            yield return StartCoroutine(moveToX(car.transform, nextPosition, 1.0f));
        }
    }
