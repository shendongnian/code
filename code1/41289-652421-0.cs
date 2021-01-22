    public override void Update() { 
        if (movingRobot) {
            OnlyUpdateRobotPosition();
        }
        else {
            DoStuffPerhapsIncludingStartingRobotMove();
        }
    }
