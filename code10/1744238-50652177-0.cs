    public void SomeFunction()
    {
        StartCoroutine("RestartScene1");
        // The code here will **not** be delayed
    }
    public IEnumerable RestartScene1()
    {
        yield return new WaitForSeconds(RestartSceneDelaySec);
        // The code here will be delayed
    }
