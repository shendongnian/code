    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedUp")
        {
             horizVel *= 10f;
        }
    }
