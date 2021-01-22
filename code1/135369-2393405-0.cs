    private static System.Text.RegularExpressions.Regex myReg = null;
    public void myMethod()
    {
        if (myReg == null)
            myReg = new Regex("\\(copy (\\d+)\\)$");
    }
