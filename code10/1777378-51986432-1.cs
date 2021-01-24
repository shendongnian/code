    public void UploadImage(string base64Image){
        StartCoroutine(
        Upload(base64Image, (response) =>{
            if (OnImageUploaded != null){
                OnImageUploaded(this, new OnImageUploadedEventArgs(response));
                Debug.Log("uploading completed!");
            }else{
                Debug.Log("OnImageUploaded = null");
            }
        }));
    }
