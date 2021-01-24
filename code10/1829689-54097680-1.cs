    class: mobile
    {
      GameObject mobileObject;
      SpriteRenderer mobileSR;
      int height;
      int width;
      public void destroy(){
      Destroy(mobileObject); //deletes GameObject
      Destroy(this); //deletes instance of class
      }
    }
