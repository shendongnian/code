    public static MyObject GetMyObject() {
       if (myObject == null) {
          MyObject newObject = new MyObject();
          newObject.Initialize(...);
          myObject = newObject;
       }
       return myObject;
    }
