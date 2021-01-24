     void Score(int value){
          score += value;
          if (score <= 0) return;
          if(score % 1000 == 0)
          {
              GameTimer.Interval *= .9f;
              if(GameTimer.Interval <= 0) GameTimer.Interval = 1;
          }
     }
