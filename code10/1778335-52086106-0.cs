    public Material rgtFace; // Is actually left facing .. derp
    public Material lftFace;  // Is actually right facing herp ... 
    public GameObject player;
    if (Input.GetKeyDown(KeyCode.A)) {
           GetComponent<Renderer>().material = rgtFace;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Renderer>().material = lftFace;
        }
	}
