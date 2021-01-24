    public IEnumerator CreateUser(string username, string password, string email)
    {
		WWWForm form = new WWWForm();
		form.AddField("UserNamePost", username);
        form.AddField("PasswordPost", password);
        form.AddField("EmailPost", email);
		UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form);
    	www.chunkedTransfer = false;
        yield return www.SendWebRequest();
		if(www.error == null){
			// you can place code here for handle a succesful post
		} else {
			// what to do on error
		}
	}
