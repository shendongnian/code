    private float _lastTime;
    IEnumerator Execute(MethodDelegate Start,MethodDelegate Stop)
    {
        while (true) {            
            // here your code must check all the event between _lastTime and Time.time
            var lastTimeMilliseconds = (int)(_lastTime*1000);
            var currentTimeMilliseconds = (int)(Time.time*1000);
            for(int time = lastTimeMilliseconds+1; time <= currentTimeMillisedons; time++)
            {
                // let's say last frame was at time 1000ms
                // This frame occurs at time 1016ms
                // we have to check your list for events that have occured since last frame (at time 1001, 1002, 1003, ...) 
                // so we have a for loop starting at 1001 until 1016 and check the list
                int res = result.IndexOf ((float)System.Math.Round (time, DigitalAdjust)-TimeAdjust);
                if (res!=-1) 
                {
                    if (res == result.Count-2) 
                    {
                        Stop.Invoke ();
                        print ("CoroutineStop");
                        StopCoroutine (_Execute);
                    }
                    //execute
                    num=Positoin[res];
                    print (res);
                    Start.Invoke();
                }
            }            
           // At the end, remember the time:
           _lastTime = Time.time;
 
            yield return null;
        }
    }
