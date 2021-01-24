     else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
    {
        activePos = new Vector3(Random.Range(-2.7f, -0.95f), 0, Random.Range(4.5f, 6f));
        return activePos;
    }
