    private System.Threading.Timer timer;
    timer = new System.Threading.Timer(GetLastCoordinate, null, 3000, 0);
    private void GetLastCoordinate()
    {
        lock(this)
        {
            Vector3 lastCoordEachThreeSecs = LastCoordinate;
        }
    }
    
