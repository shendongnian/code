    public void SignInWithEmail()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
         DatabaseReference.GetValueAsync().ContinueWith(task => {
             //Here's the fix
             UnityMainThreadDispatcher.Instance().Enqueue(ShowUserPanel());
        }
      }
    }
	public IEnumerator ShowUserPanel()
	{
		uiController.userPanel.panel.SetActive(true);
		uiController.authPanel.SetActive(false);
		yield return null;
	}
