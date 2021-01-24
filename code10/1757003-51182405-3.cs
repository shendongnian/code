    IEnumerator Fish()
    {
        timeBeforeBite = UnityEngine.Random.Range(50f, 100f);
        while (isFishing == true)
        {
            if (timerToBite >= timeBeforeBite)
            {
                Debug.Log("Reel Now!");
                fishOnLine = true;
                isFishing = false;
                timerToBite = 0f;
            }
            timerToBite += Time.deltaTime;
            yield return null; // return within the while-loop
        }
    }
