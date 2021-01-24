    private void Update()
    {
        bool w, a, s, d;
        w = Input.GetKeyDown(KeyCode.W);
        a = Input.GetKeyDown(KeyCode.A);
        s = Input.GetKeyDown(KeyCode.S);
        d = Input.GetKeyDown(KeyCode.D);
    
        if (w)
        {
            StopAllCoroutines();
            StartCoroutine (HandleKey(KeyCode.W));
        }
        else if (a)
        {
            StopAllCoroutines();
            StartCoroutine (HandleKey(KeyCode.A))
        }
        else if (s)
        {
            StopAllCoroutines();
            StartCoroutine (HandleKey(KeyCode.S))
        }
        else if (d)
        {
            StopAllCoroutines();
            StartCoroutine (HandleKey(KeyCode.D))
        }
    }
    
    private IEnumerator HandeKey(KeyCode code)
    {
        Vector3 vector;
    
        Switch(code)
        {
            case KeyCode.W:
                vector = transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
                break;
    
            
            case KeyCode.A:
                vector = transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
    
                break;
    
            case KeyCode.D:
                vector = transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
                break;
    
            case KeyCode.S:
                vector = transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
                break;
        }
    
        while(Input.GetKey(code))
        {
            transform.Translate(vector);
            yield return null;
        }
    }
