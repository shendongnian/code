    // you can change it in the inspector which is handy
    // if i'th value of this array is false
    // then i'th CircleDrawer GameObject in objectsToAddCircles array
    // won't be affected by this manager
    public bool changableCircle[];
    void Start() {
        // your code
        changableCircle = new bool[objectsToAddCircles.Length];
    }
    void Update() {
        for(...) {
            // values which are always overwritten by manager
            if(changableCircle[i]) {
                // values which you don't want to be changed by this manager
            }
        }
    }
