    public bool isDone;
    Script1 script1Ref;
    
    public IEnumerator Start()
    {
        GameObject s1Obj = GameObject.Find("GameObjectScript1IsAttachedTo");
        script1Ref = s1Obj.GetComponent<Script1>();
    
        //Wait here until we are done
        while (script1Ref.isDone)
            yield return null;
    
        //Done Waiting, now continue with the rest of the code
        Function1();
        String blah = "Things";
        Function2();
        StartCoroutine(Routine2());
        StartCoroutine(Routine3());
    }
