    void OnMouseOver()
    {
        isHovered = true;
        Debug.Log("Mouse is over game object.");
        if (Input.GetKey(KeyCode.X) && !hitState)
        {
            hitState = true;
            hitSound.Play();
           
            // we want to delay for half a second before processing the hit.
            float delaySeconds = 0.5; 
            IEnumerator coroutine = WaitToDie(delaySeconds);
            StartCoroutine(coroutine);
        }
    }
