    private void Reco_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
    	string a = e.Result.Text;
    
    	switch (a)
    	{
    		case ("cat"):
    			{
    				s.SpeakAsync("dog");
    				break;
    			}
    		case ("dog"):
    			{
    				s.SpeakAsync("cat");
    				break;
    			}
    	}
    }
