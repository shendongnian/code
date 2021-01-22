            while (true)
            {
                if(DateTime.Now.ToString("HH:mm") == "22:00")
                {
                    //do something here
                    //ExecuteFunctionTask();
                    //Make sure it doesn't execute twice by pausing 61 seconds. So that the time is past 2200 to 2201
                    Thread.Sleep(61000);
                }
                Thread.Sleep(10000);
            }
