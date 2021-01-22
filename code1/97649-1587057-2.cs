   void Update()
   {
      switch (State)
      {
         case StateEnum.Moving:
            AI.Location.Offset(AI.Velocity); //advance 0.5 pixels to the right
            break;
         default:
            break;
      }
   }
}
