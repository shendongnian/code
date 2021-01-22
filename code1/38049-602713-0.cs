    private void DoSomething() {
        try {
            DataTable dt = ReturnSomething();
        }
        catch (Exception ex) {
        }    
    }
    public DataTable ReturnSomething() {
        DataTable dt = new DataTable();
        // logic here
        return dt;
    }
