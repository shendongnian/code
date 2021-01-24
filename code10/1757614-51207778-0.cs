    public Vector3 a;
    public Vector3 b;
    public float speed;
    public float distance;
    void Update(){
        distance += Time.deltaTime;
        transform.position = Vector3.Lerp(a, b, Mathf.PingPong(distance * speed, 1.0f));
    }
