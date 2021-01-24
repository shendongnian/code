        float x = Input.GetAxis("Horizontal")
        float y = Input.GetAxis("Vertical");
        float lerpAmount= 10;
        if (x != 0 || y != 0) 
        {
            toRotate.rotation = Quaternion.Lerp(
                toRotate.rotation,
                Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg),
                lerpAmount * Time.deltaTime);
        }
