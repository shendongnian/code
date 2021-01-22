    class MyPinAnnotationView
    {
      private GamePlay gamePlay;
      public MyPinAnnotationView(GamePlay gamePlay)
      {
        this.gamePlay = gamePlay;
      }
      public void TouchesBegan()
      {
        this.gamePlay.CheckAnswer();
      }
    }
