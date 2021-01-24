    public void MoveGameObject(GameObject go, double Y,  double currentX, double desiredX, double moveSpeed)
    {
        double K = moveSpeed * 0.1; //Try different moveSpeed for effect
        double D = (desiredX - currentX) / K;
        double X = currentX;
        
        for(int I = 0; I < K; I++)
        {
            X += D;
            go.transform.position = new Vector2 (X, Y);
        }
    }
