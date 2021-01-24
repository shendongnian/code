    public IEnumerator TryConnection(int index)
    {
        if (handlers.count > index)
        {
            //Get next handler here
            Handler handler = handlers[index];
            UnityWebRequest www = UnityWebRequest.Get(handler.url);
            www.timeout = 5;
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                StartCoroutine(TryConnection(index++));
            }
            else
            {
                handler.init();
            }
        }        
    }
