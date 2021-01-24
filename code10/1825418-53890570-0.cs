    private bool CRRegenerateIsRunning = false;
    void FixedUpdate ()
    {
        if (Player1.canRegenerate && health < 100f)
        {
            health += 0.5f;
        }
        if (!Player1.canRegenerate && !CRRegenerateIsRunning)
        {
            StartCoroutine(Regenerate());
        }
    }
    IEnumerator Regenerate()
    {
        CRRegenerateIsRunning = true;
        yield return new WaitForSeconds(5);
        
        Player1.canRegenerate = true;
        CRRegenerateIsRunning = false;
    }
