    private void Update()
        {
            Vector2 v1 = new Vector2(blade.transform.position.x, blade.transform.position.y);
            Vector2 v2 = new Vector2(bladeLastPos.x, bladeLastPos.y);
            float maxRange = Vector2.Distance(v1,v2);
            RaycastHit2D hit = Physics2D.Raycast(v1, v2-v1, maxRange);
            if (hit.collider == GetComponent<Collider2D>() as Collider2D)
            {
                print("hi");
            }
            bladeLastPos = new Vector3(blade.position.x,blade.position.y,blade.position.z); 
        }
