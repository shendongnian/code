    IEnumerator DownloadFile(string url) {
    		  			 
    		var docName = url.Split('/').Last(); 
            var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET);
    		 
    	    string modelSavePath = Path.Combine(Application.dataPath, "Objects");
    	    modelSavePath = Path.Combine(modelSavePath, docName);
    	 
    		//Create Directory if it does not exist
    			if (!Directory.Exists(Path.GetDirectoryName(modelSavePath)))
    			{
    				Directory.CreateDirectory(Path.GetDirectoryName(modelSavePath));
    			}
     
     		var dh = new DownloadHandlerFile(modelSavePath);
            dh.removeFileOnAbort = true; 
            uwr.downloadHandler = dh;  
     
            yield return uwr.SendWebRequest();
    		 
            if (uwr.isNetworkError || uwr.isHttpError)
                Debug.LogError(uwr.error);
            else
                Debug.Log("File successfully downloaded and saved to " + modelSavePath);
        }
