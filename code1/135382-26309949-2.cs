    private Regex myReg = null;
    private Regex MyReg
    {
        get {
            if (myReg == null)
                myReg = new Regex("\\(copy (\\d+)\\)$");
            return myReg;
        }
    }
