    public float speed;
        private void Update()
        {
    
            Vector3 someVector3;
    
    
            someVector3.x = Input.GetAxisRaw("mouse x") * speed * Time.deltaTime;
            someVector3.y = Input.GetAxisRaw("mouse y") * speed * Time.deltaTime;
            someVector3.z = 0;
    
            transform.position += someVector3;
        }
    }
