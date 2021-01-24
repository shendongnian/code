        public void Initialize(ITelemetry telemetry)
        {
            Activity current = Activity.Current;
    
            if (current == null)
            {
                current = (Activity)HttpContext.Current?.Items["__AspnetActivity__"];
    //put your code here
            }
    }
