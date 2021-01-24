    private RelayCommand<Double> rotateClockWiseCommand;
    
    public RelayCommand<Double> RotateClockWiseCommand
    {
        get
        {
            return rotateClockWiseCommand
            ?? (rotateClockWiseCommand = new RelayCommand<Double>(
            (increase) =>
            {
                if(Facing + increase > 359)
                {
                    Facing = 0;
                }
                else
                {
                    Facing += increase;
                }
            }));
        }
    }
