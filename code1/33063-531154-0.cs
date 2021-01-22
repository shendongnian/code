        Queue<TimerDelegate> eventQueue = new Queue<TimerDelegate>();
    
        public Vehicle(IVehicle veh, Canvas arena, Dispatcher battleArenaDispatcher)
        {
             DispatcherTimer actionTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(100) };
             actionTimer.Tick += new EventHandler(delegate(object sender, EventArgs e)
        {
            if (IsActionRunning || eventQueue.Count == 0)
            {
                return;
            }
            eventQueue.Dequeue().Invoke(new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(5) });
        });
        actionTimer.Start();
        }
        public void TurnRight(double deg)
        {
            eventQueue.Enqueue((TimerDelegate)delegate(DispatcherTimer dt)
            {
                IsActionRunning = true;
                var currAngle = 0;
                dt.Tick += new EventHandler(delegate(object sender, EventArgs e)
                {
                    lock (threadLocker)
                    {
                        if (currAngle >= deg)
                        {
                            IsActionRunning = false;
                            dt.Stop();
                        }
                        Rotator_Body.Angle++;
                        currAngle++;
                    }
                });
                dt.Start();
            });
        }
