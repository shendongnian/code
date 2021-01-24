    public void handleUserInput()
    {
            if (Input.GetButtonDown("Fire3"))
            {
                deleteAllChildren();
                chooseTrial.chooseNextTrial();
                chooseTrial.countTrial++;
            }
    }
