    for (i = 0; i < 8; i++)
    {
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.position = new Vector3(i * 1, 0, 0);
        MeshRenderer mesh = quad.GetComponent<MeshRenderer>();        
        if (i%2 != 0) // if i is odd
        {
            mesh.material = (Material)Resources.Load("Charcoal");
        } else // if i is even
        {
            mesh.material = (Material)Resources.Load("Bone");
        }
    }
