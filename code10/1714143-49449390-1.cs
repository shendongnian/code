    float lastTimePressedButton;
    void Start() {
        lastTimePressedButton = Time.time;
    }
    void Update() {
    if(Input.GetKeyCode(KeyCode.S)) {
        lastTimePressedButton = Time.time;
    }
    if(Time.time >= lastTimePressedButton + 5f) {
         ResetEnemyOrWhatever();
         lastTimePressedButton = Time.time;
    }
