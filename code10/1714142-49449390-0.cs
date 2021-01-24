    float lastTimePressedButton;
    void Start() {
        lastTimePressedButton = Time.time;
    }
    void Update() {
    if(Input.GetKeyCode(KeyCode.S)) {
        lastTimePressedButton = Time.time;
    }
    if(Time.time + 5f >= lastTimePressedButton) {
         ResetEnemyOrWhatever();
    }
