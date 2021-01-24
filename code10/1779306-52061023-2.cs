    public GameObject gun = Pshoot.gun; // Right facing gun
    public GameObject gun1 = Pshoot.gun1; // Left facing gun
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
           GetComponent<Renderer>().material = rgtFace;
            gun.SetActive(false);
            gun1.SetActive(true);
           // isFacingRight = false;
           // FaceLeft();
          // gun.transform.localScale = new Vector3(-1,1,-1);
        }
