    [HttpPost]
    public ActionResult Welcome()
    {
	    var response = new VoiceResponse();
	    try
	    {
		    var gatherOptionsList = new List<Gather.InputEnum>
		    {
			    Gather.InputEnum.Speech,
			    //Gather.InputEnum.Dtmf
		    };
		    var gather = new Gather(
			    input: gatherOptionsList,
			    timeout: 60,
			    finishOnKey:"*",
			    action: Url.ActionUri("OnGatherComplete", "Ivr")
			    );
		    gather.Say("Please say \n", Say.VoiceEnum.Alice, 1, Say.LanguageEnum.EnGb);
		    response.Append(gather);		   
	    }
	    catch (Exception e)
	    {
		    ErrorLog.LogError(e, "Error within ivr/Welcome");		    
	    }
	    return TwiML(response);
    }
    [HttpPost]
    public TwiMLResult OnGatherComplete(string SpeechResult, double Confidence)
    {
	    var response = new VoiceResponse();
	    try
	    {
		    var identifyingConfidence = Math.Round(Confidence * 100, 2);
		    var transcript = $"You said {SpeechResult} with Confidence {identifyingConfidence}.\n Good Bye";
		    var say = new Say(transcript);		   
		    response.Append(say);
	    }
	    catch (Exception e)
	    {
		    ErrorLog.LogError(e, "Error within ivr/OnGatherComplete");		    
	    }
	    return TwiML(response);
    }
