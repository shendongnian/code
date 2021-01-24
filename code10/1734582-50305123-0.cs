    if (Input.GetKeyDown(KeyCode.D)) {
      state = State.RIGHT;
    }
    if (Input.GetKeyDown(KeyCode.A)) {
      state = State.LEFT;
    }
    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) {
      state = State.IDLE;
    }
    switch (state) {
      case State.LEFT:
        rd.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        rd.transform.eulerAngles = new Vector3(0, 10, 0);
      break;
      case State.RIGHT:
        rd.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        rd.transform.eulerAngles = new Vector3(0, -10 , 0);
      break;
      case State.IDLE:
        rd.transform.eulerAngles = Vector3.zero;
      break;
    }
