    // Assign the game objects manually from the Unity interface via drag and drop. That is why public GameObject[].
    Public GameObject[] ParticleSystems;
    Private String[] YourEmotions;
    float activationDuration = 15f;
    
    // Your code to retrieve the txt value and assign to 'YourEmotions' array, or use YourEmotions = {"Angry", "Sad", "Happy"};. Have the order match the order of the equivalent game object. Then when you need the particle system, active it by calling StartParticularParticleSystem and passing in the string identifier of the one you want to use.
    // ...
    
    Public Void StartParticularParticleSystem(string Emotion)
    {
    
        for(int i = 0; i < ParticleSystems.Count; i++)
        {
           if(Emotion == YourEmotions[i])
           {
              StartCoroutine(MyCoroutine(ParticleSystems[i]));
           }
        }
    
    }
    
    IEnumerator MyCoroutine (GameObject ObjectToActivate)
    {
        ObjectToActivate.SetActive(True);    
        yield return new WaitForSeconds(activationDuration);
        ObjectToActivate.SetActive(False);
    }
