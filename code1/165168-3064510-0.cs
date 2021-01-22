    public void Start()
    {
        var handler = this.StartedWorking;
        if (handler != null)
        {
             handler(this, eventArgObject);
        }
    }
