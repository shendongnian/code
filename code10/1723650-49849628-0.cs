    public void uploadToAWS()
    {
        fileNameList = "";
        string[] files = Directory.GetFiles(".", "*.txt");
        for (int i = 0; i < files.Length; i++)
        {
            WWWForm AWSform = new WWWForm();
            AWSform.AddField("key", "AffectivaLogs/${filename}");
            AWSform.AddBinaryData("file", File.ReadAllBytes(files[i]), files[i], "text/plain");
            StartCoroutine(Post(FILEUPLOAD_BASE_URL, AWSform));
            fileNameList += files[i].Replace(@".\", "") + "  ||  ";
        }
    } 
    IEnumerator Post(string url, WWWForm form)
    {               
        WWW www = new WWW(url, form);
        float elapsedTime = 0.0f;
        while (!www.isDone)
        {
            elapsedTime += Time.deltaTime;
            //Matrix4x4 wait time is 20s
            if (elapsedTime >= 20f)
            {
                break;
            }
            yield return null;
        }
        if (!www.isDone || !string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Connection error while sending analytics... Error:" + www.error);
            // Error handling here.
            yield break;
        }
    
        if (www.isDone)
        {            
            Debug.Log("Data Sent successfully.");
            yield break;
        }        
    }
