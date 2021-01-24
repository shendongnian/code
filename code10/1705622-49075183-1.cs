    IEnumerator StartUpload(string item_path)
    {
         // Code
        using (UnityWebRequest www = UnityWebRequest.Post("somelink.com/upload", form))
        {
             yield return www.Send();
            while (!www.isDone)
            {
               Debug.Log(www.progress);
               yield return null
            }
            Debug.Log("Success!");
        }
    }
