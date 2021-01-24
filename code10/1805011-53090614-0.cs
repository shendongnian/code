    // Update is called once per frame
    void Update () {
        var horizVel = 0;
        if (Input.GetKey(moveL))
        {
            horizVel += 3;
        }
        if (Input.GetKey(moveR))
        {
            horizVel -= 3;
    	}
    
    	GetComponent<Rigidbody>().MovePosition(this.transform.position + new Vector3(-4, GM.vertVol, horizVel) * Time.deltaTime);
    }
}
