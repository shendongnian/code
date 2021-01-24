    if(!Input.GetKey(KeyCode.LeftShift)
    {
        if (Input.GetKey(KeyCode.W))
        {
             tf.position += (Vector3.up * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
             tf.position += (Vector3.left * speed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
             tf.position += (Vector3.down * speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
             tf.position += (Vector3.right * speed);
        }
    }
    else
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
             tf.position += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
             tf.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
             tf.position += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
             tf.position += Vector3.right;
        }
    }
