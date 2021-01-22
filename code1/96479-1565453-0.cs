     namespace ThreadingSimulation
     {
     
       // A Random Activity can be picked up from this enum by a team
     
        public enum RandomGroundStatus
        {
            Free,
            Allotted,
            Wet          
        }
     
     class FootBallGround
     {
         private Team _currentTeam;
         // Set the initial state to true so that the first thread that 
         // tries to get the lock will succeed
         private ManualResetEvent _groundsLock = new ManualResetEvent(true);
         public bool Playing(Team obj)
         {
           // Here the name of the team which is using the  ground will be printed
           // Once the time is reached to 25 minutes the active thread the lock will
           // signal other threads    
           if (!_groundsLock.WaitOne(10))
             return false;
           _currentTeam = obj;
           
           // Reset the event handle so that no other thread can come into this method
           _groundsLock.Reset();    
           // Now we start a separate thread to "timeout" this team's lock 
           // on the football grounds after 25 minutes
           ThreadPool.QueueUserWorkItem(WaitForTimeout(25));                  
         }
     
        public void GroundCleaningInProgress(object obj)
        {
     
           // Ground cleaning is in progress all of you wait for 10 minutes
     
        }
        private void WaitForTimeout(object state)
        {
             int timeout = (int)state;
             // convert the number we specified into a value equivalent in minutes
             int milliseconds = timeout * 1000;
             int minutes = milliseconds * 60;
             // wait for the timeout specified 
             Thread.Sleep(minutes);
             // now we can set the lock so another team can play
             _groundsLock.Set();
         }
     }    
     
     class Team
      {
          string teamName;  
          FootBallGround _ground;
           public Team(string teamName, FootBallGround ground)
           {
              this.teamName = teamName;
              this._ground = ground;      
           }
           public bool PlayGame()
           {
                // this method returns true if the team has acquired the lock to the grounds
                // otherwise it returns false and allows other teams to access the grounds
                if (!_ground.Playing(this))
                   return false;
                else
                   return true;
           }
      }
      static void Main()
      {
             Team teamA = new Team();
             Team teamB = new Team();
 
             // select random value for GrandStatus from enum
             RandomGroundStatus status = <Generate_Random_Status>;
             // if the ground is wet no team is allowed to get the
             // ground for 10 minutes.
             if (status == RandomGroundStatus.Wet)
                ThreadPool.QueueUserWorkItem(WaitForDryGround);
             else
             {
                 // if the ground is free, "Team A" locks the ground
                 // otherwise "Team B" locks the ground
                 if (status == RandomGroundStatus.Free)
                 {
                   if (!teamA.PlayGame())
                      teamB.PlayGame();
                 }
              }
        }
