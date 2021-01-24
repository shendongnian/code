    AudioListener[] aL = FindObjectsOfType<AudioListener>();
    for (int i = 0; i < aL.Length; i++)
    {
        //Destroy if AudioListener is not on the MainCamera
        if (!aL[i].CompareTag("MainCamera"))
        {
            DestroyImmediate(aL[i]);
        }
    }
