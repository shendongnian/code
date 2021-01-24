    public void Move()
    {
        int n = Nodes.Count;
        if (n > 0)
        {
            for (int i = n - 1; i > 0; i--)
            {
                _curNode = Nodes[i];
                _nextNode = Nodes[i - 1];
                Vector3 pos = _nextNode.transform.position;
                pos.z = Nodes[0].position.z;
                _curNode.tranform.position = pos;
            }
            float horizontalInput = Input.GetAxis("Horizontal");
            Nodes[0].Translate(Vector3.right * Time.deltaTime * horizontalInput * 10);
            Nodes[0].Translate(Vector3.up * Time.deltaTime * 4);
    
            if (Nodes[0].position.x > 2.90)
            {
                Nodes[0].position = new Vector2(2.90f, Nodes[0].position.y);
            }
            else if (Nodes[0].position.x < -2.90)
            {
                Nodes[0].position = new Vector2(-2.90f, Nodes[0].position.y);
            }
        }    
    }
