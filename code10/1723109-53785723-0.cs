    using SpeechLib;
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    
    class VAInline
    {
    	// Initialize variables needed throughout this code
    	ISpeechRecoGrammar grammar; // Declare the grammar
    	SpFileStream FileStream; // Declare the voice recognition input file stream
    	string AudioPath = null; // Declare directory path to wav file
    	string GrammarPath = null; // Declare directory path to grammar file
    	string RecognitionFlag = "";
    	string RecognitionConfidence = "";
    	bool UseDictation; // Declare boolean variable for storing pronunciation dictation grammar setting
    	
    	public void main()
    	{
    		// Reset relevant VoiceAttack text variables
    		VA.SetText("~~RecognitionError", null);
    		VA.SetText("~~RecognizedText", null);
    		VA.SetText("~~SAPIPhonemes", null);
    		VA.SetText("~~SAPIPhonemesRaw", null);
    		//VA.SetText("~~FalseRecognitionFlag", null);
    		
    		// Retrieve the desired word data contained within VoiceAttack text variable
    		string ProcessText = null; // Initialize string variable for storing the text of interest
    		if (VA.GetText("~~ProcessText") != null) // Check if user provided valid text in input variable
    			ProcessText = VA.GetText("~~ProcessText"); // Store text of interest held by VA text variable
    		else
    		{
    			VA.SetText("~~RecognitionError", "Error in input text string (SAPI)"); // Send error detail back to VoiceAttack as text variable
    			return; // End code processing
    		}
    		
    		// Retrieve path to speech grammar XML file from VoiceAttack
    		GrammarPath = VA.GetText("~~GrammarFilePath");
    		
    		// Retrieve path to voice recognition input wav file from VoiceAttack
    		AudioPath = VA.GetText("~~AudioFilePath");
    		
    		// Check if TTS engine is voicing the input for the speech recognition engine
    		if (VA.GetBoolean("~~UserVoiceInput") == false)
    		{
    			//VA.WriteToLog("creating wav file");
    			if (TextToWav(AudioPath, ProcessText) == false) // Create wav file with specified path that voices specified text (with text-to-speech) and check if the creation was NOT successful
    				return; // Stop executing the code
    		}
    		
    		// Create speech recognizer and associated context
    		SpInprocRecognizer MyRecognizer = new SpInprocRecognizer(); // Create new instance of SpInprocRecognizer
    		SpInProcRecoContext RecoContext = (SpInProcRecoContext)MyRecognizer.CreateRecoContext(); // Initialize the SpInProcRecoContext (in-process recognition context)
    		
    		try // Attempt the following code
    		{
    			// Open the created wav in a new FileStream
    			FileStream = new SpFileStream(); // Create new instance of SpFileStream
    			FileStream.Open(AudioPath, SpeechStreamFileMode.SSFMOpenForRead, true); // Open the specified file in the FileStream for reading with events enabled
    			
    			// Set the voice recognition input as the FileStream
    			MyRecognizer.AudioInputStream = FileStream; // This will internally "speak" the wav file for input into the voice recognition engine
    			
    			// Set up recognition event handling
    			RecoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoContext_Recognition); // Register for successful voice recognition events
    			RecoContext.FalseRecognition += new _ISpeechRecoContextEvents_FalseRecognitionEventHandler(RecoContext_FalseRecognition); // Register for failed (low confidence) voice recognition events
    			if (VA.GetBoolean("~~ShowRecognitionHypothesis") == true) // Check if user wants to show voice recognition hypothesis results
    				RecoContext.Hypothesis += new _ISpeechRecoContextEvents_HypothesisEventHandler(RecoContext_Hypothesis); // Register for voice recognition hypothesis events
    			RecoContext.EndStream += new _ISpeechRecoContextEvents_EndStreamEventHandler(RecoContext_EndStream); // Register for end of file stream events
    			
    			// Set up the grammar
    			grammar = RecoContext.CreateGrammar(); // Initialize the grammar object
    			UseDictation = (bool?)VA.GetBoolean("~~UseDictation") ?? false; // Set UserDictation based on value from VoiceAttack boolean variable
    			if (UseDictation == true) // Check if pronunciation dictation grammar should be used with speech recognition
    			{
    				//grammar.DictationLoad("", SpeechLoadOption.SLOStatic); // Load blank dictation topic into the grammar
    				grammar.DictationLoad("Pronunciation", SpeechLoadOption.SLOStatic); // Load pronunciation dictation topic into the grammar so that the raw (unfiltered) phonemes may be retrieved
    				grammar.DictationSetState(SpeechRuleState.SGDSActive); // Activate dictation grammar
    			}
    			else
    			{
    				grammar.CmdLoadFromFile(GrammarPath, SpeechLoadOption.SLODynamic); // Load custom XML grammar file
    				grammar.CmdSetRuleIdState(0, SpeechRuleState.SGDSActive); // Activate the loaded grammar
    			}
    			Application.Run(); // Starts a standard application message loop on the current thread
    		}
    		catch // Handle exceptions in above code
    		{
    			VA.SetText("~~RecognitionError", "Error during voice recognition setup (SAPI)"); // Send error detail back to VoiceAttack as text variable
    			return; // Stop executing the code
    		}
    		finally // Runs whether an exception is encountered or not
    		{
    			MyRecognizer = null; // Set to null in preparation for garbage collection
    			FileStream.Close(); // Close the input FileStream
    			FileStream = null; // Set to null in preparation for garbage collection
    			
    			// Close up recognition event handling
    			RecoContext.Recognition -= new _ISpeechRecoContextEvents_RecognitionEventHandler(RecoContext_Recognition); // Unregister for successful voice recognition events
    			RecoContext.FalseRecognition -= new _ISpeechRecoContextEvents_FalseRecognitionEventHandler(RecoContext_FalseRecognition); // Unregister for failed (low confidence) voice recognition events
    			if (VA.GetBoolean("~~ShowRecognitionHypothesis") == true) // Check if user wanted to show voice recognition hypothesis results
    				RecoContext.Hypothesis -= new _ISpeechRecoContextEvents_HypothesisEventHandler(RecoContext_Hypothesis); // Unregister for voice recognition hypothesis events
    			RecoContext.EndStream -= new _ISpeechRecoContextEvents_EndStreamEventHandler(RecoContext_EndStream); // Unregister for end of file stream events
    			RecoContext = null; // Set to null in preparation for garbage collection
    		}
    		//VA.WriteToLog("voice recognition complete"); // Output info to event log
    	}
    
    	// Function for converting text to a voiced wav file via text-to-speech
    	public bool TextToWav(string FilePath, string text)
    	{
    		//VA.WriteToLog("creating wav file"); // Output info to event log
    		SpFileStream stream = new SpFileStream(); // Create new SpFileStream instance
    		try // Attempt the following code
    		{
    			if (System.IO.File.Exists(FilePath) == true) // Check if voice recognition wav file already exists
    				System.IO.File.Delete(FilePath); // Delete existing voice recognition wav file
    			stream.Format.Type = SpeechAudioFormatType.SAFT48kHz16BitStereo; // Set the file stream audio format
    			stream.Open(FilePath, SpeechStreamFileMode.SSFMCreateForWrite, true); // Open the specified file for writing with events enabled
    			SpVoice voice = new SpVoice(); // Create new SPVoice instance
    			voice.Volume = 100; // Set the volume level of the text-to-speech voice
    			voice.Rate = -2; // Set the rate at which text is spoken by the text-to-speech engine
    			string NameAttribute = "Name = " + VA.GetText("~~TextToSpeechVoice");
    			voice.Voice = voice.GetVoices(NameAttribute).Item(0);
    			//voice.Speak(text);
    			voice.AudioOutputStream = stream; // Send the audio output to the file stream
    			voice.Speak(text, SpeechVoiceSpeakFlags.SVSFDefault); // Internally "speak" the inputted text (which records it in the wav file)
    			voice = null; // Set to null in preparation for garbage collection
    		}
    		catch // Handle exceptions in above code
    		{
    			VA.SetText("~~RecognitionError", "Error during wav file creation (SAPI)"); // Send error detail back to VoiceAttack as text variable
    			return false; // Send "false" back to calling code line
    		}
    		finally // Runs whether an exception is encountered or not
    		{
    			stream.Close(); // Close the file stream
    			stream = null; // Set to null in preparation for garbage collection
    		}
    		return true; // Send "true" back to calling code line
    	}
    
    	// Event handler for successful (higher confidence) voice recognition
    	public void RecoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
    	{
    		//VA.WriteToLog("Recognition successful"); // Output info to event log
    		
    		//VA.SetText("~~FalseRecognitionFlag", ""); // Send blank recognition flag ("") back to VoiceAttack as text variable
    		//RecognitionFlag = ""; // Set the RecognitionFlag as blank
    		RecognitionProcessing(Result); // Process the voice recognition result
    		//if (UseDictation == false) // Check if pronunciation dictation grammar should NOT be used with speech recognition
    		GetPhonemes(Result); // Retrieve SAPI phonemes from recognition result
    	}
    
    	// Event handler for unsuccessful (low confidence) voice recognition
    	public void RecoContext_FalseRecognition(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
    	{
    		//VA.WriteToLog("Low confidence recognition"); // Output info to event log
    		
    		//VA.WriteToLog(Result.PhraseInfo.GetText());
    		//VA.SetText("~~FalseRecognitionFlag", "*"); // Send unsuccessful recognition flag (text character) back to VoiceAttack as text variable
    		RecognitionFlag = "*"; // Set the RecognitionFlag as "*"
    		RecognitionProcessing(Result); // Process the voice recognition result
    		GetPhonemes(Result); // Retrieve SAPI phonemes from recognition result
    	}
    
    	// Event handler for voice recognition hypotheses
    	public void RecoContext_Hypothesis(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
    	{
    		//VA.WriteToLog("Recognition hypothesis"); // Output info to event log
    		
    		float confidence = Result.PhraseInfo.Elements.Item(0).EngineConfidence;
    		VA.WriteToLog("Hypothesis = " + Result.PhraseInfo.GetText() + " (" + Decimal.Round(Convert.ToDecimal(confidence), (confidence > 0.01 ? 3 : 4)) + ")"); // Output info to event log
    	}
    
    	// Event handler for reaching the end of an audio input stream
    	public void RecoContext_EndStream(int StreamNumber, object StreamPosition, bool StreamReleased)
    	{
    		// VA.WriteToLog("End of stream, cleaning up now"); // Output info to event log
    		
    		// Clean up now that voice recognition is complete
    		try // Attempt the following code
    		{
    			if (UseDictation == true)
    				grammar.DictationSetState(SpeechRuleState.SGDSInactive); // Deactivate dictation grammar
    			else
    				grammar.CmdSetRuleIdState(0, SpeechRuleState.SGDSInactive); // Deactivate the loaded grammar
    		}
    		catch // Handle exceptions in above code
    		{
    			VA.SetText("~~RecognitionError", "Error during cleanup process (SAPI)"); // Send error detail back to VoiceAttack as text variable
    		}
    		finally // Runs whether an exception is encountered or not
    		{
    			Application.ExitThread(); // Terminates the message loop on the current thread
    		}
    	}
    
    	// Function for processing voice recognition results
    	public void RecognitionProcessing(ISpeechRecoResult Result)
    	{
    		//VA.WriteToLog("Processing recognition result"); // Output info to event log
    		
    		try // Attempt the following code
    		{
    			string RecognizedText = Result.PhraseInfo.GetText().Trim(); // Store recognized text	
    			float confidence = Result.PhraseInfo.Elements.Item(0).EngineConfidence; // Get confidence of voice recognition result
    			decimal RecognitionConfidenceScore = Decimal.Round(Convert.ToDecimal(confidence), (confidence > 0.01 ? 3 : 4)); // Calculate confidence of voice recognition result convert to decimal, and round the result
    			string RecognitionConfidenceLevel = Result.PhraseInfo.Elements.Item(0).ActualConfidence.ToString().Replace("SEC", "").Replace("Confidence", "");
    			VA.SetText("~~RecognizedText", RecognizedText); // Send recognized text back to VoiceAttack as text variable
    			//VA.SetText("~~RecognitionConfidenceLevel", RecognitionConfidenceLevel); // Send speech recognition confidence level back to VoiceAttack as text variable
    			//VA.SetDecimal("~~RecognitionConfidence", RecognitionConfidenceScore); // Send recognized confidence back to VoiceAttack as decimal variable
    			
    			if (VA.GetBoolean("~~ShowConfidence") == true)
    				RecognitionConfidence = "(" + RecognitionConfidenceLevel + " @ " + RecognitionConfidenceScore.ToString() + ")" + RecognitionFlag;
    			//VA.SetText("~~RecognitionConfidence", RecognitionConfidenceLevel + " @ " + RecognitionConfidenceScore.ToString()); // Send speech recognition confidence data back to VoiceAttack as text variable
    			VA.SetText("~~RecognitionConfidence", RecognitionConfidence); // Send formatted speech recognition confidence data back to VoiceAttack as text variable
    			if (UseDictation == true) // Check if pronunciation dictation grammar should be used with speech recognition
    			{
    				RecognizedText = RecognizedText.Replace("hh", "h"); // Replace any instances of "hh" in recognized phonemes with "h"
    				VA.SetText("~~SAPIPhonemes", RecognizedText); // Send word-delimited SAPI phoneme data back to VoiceAttack as text variable
    			}
    		}
    		catch (Exception e) // Handle exceptions in above code
    		{
    			VA.WriteToLog(e.ToString());
    			VA.SetText("~~RecognitionError", "Error during processing of recognition result (SAPI)"); // Send error detail back to VoiceAttack as text variable
    		}
    	}
    
    	// Function for extracting SAPI phonemes from voice recognition results
    	public void GetPhonemes(ISpeechRecoResult Result)
    	{
    		//VA.WriteToLog("Extracting phonemes from voice recognition result"); // Output info to event log
    		
    		try // Attempt the following code
    		{
    			SpPhoneConverter MyPhoneConverter = new SpPhoneConverter(); // Create new SPPhoneConverter instance
    			MyPhoneConverter.LanguageId = 1033; // Set the phone converter's language (English = 1033)
    			string SAPIPhonemesRaw = null; // Initialize string for storing raw SAPI phoneme data
    			string SAPIPhonemes = null; // Initialize string for storing delimited SAPI phoneme data
    			int i = 1; // Initialize integer for tracking phoneme count
    			string WordSeparator = " "; // Initialize string variable for storing the characters used to separate words within the phoneme result
    			
    			if (VA.GetBoolean("~~SeparatePhonemes") == true) // Check if user wants to have the "-" character separate the words within the phoneme result
    				WordSeparator = " - "; // Redefine the WordSeparator			
    			foreach (ISpeechPhraseElement MyPhrase in Result.PhraseInfo.Elements) // Loop through each element of the recognized text
    			{
    				if (MyPhrase.DisplayText != " ")
    				{
    					SAPIPhonemesRaw += " " + MyPhoneConverter.IdToPhone(MyPhrase.Pronunciation); // Build string of SAPI phonemes extracted from the recognized text
    					SAPIPhonemes += (i++ > 1 ? WordSeparator : " ") + MyPhoneConverter.IdToPhone(MyPhrase.Pronunciation); // Build string of SAPI phonemes extracted from the recognized text, delimited by " "
    				}
    			}
    			MyPhoneConverter = null; // Set to null in preparation for garbage collection
    			
    			VA.SetText("~~SAPIPhonemesRaw", SAPIPhonemesRaw.Trim()); // Send raw SAPI phoneme data back to VoiceAttack as text variable
    			VA.SetText("~~SAPIPhonemes", SAPIPhonemes.Trim()); // Send word-delimited SAPI phoneme data back to VoiceAttack as text variable
    		}
    		catch // Handle exceptions in above code
    		{
    			VA.SetText("~~RecognitionError", "Error during phoneme extraction"); // Send error detail back to VoiceAttack as text variable
    		}
    	}
    }
    
    // References:
    // https://github.com/rti7743/rtilabs/blob/master/files/asobiba/DictationFilter/DictationFilter/SpeechRecognitionRegexp.cs
    // https://stackoverflow.com/questions/6193874/help-with-sapi-v5-1-speechrecognitionengine-always-gives-same-wrong-result-with/6203533#6203533
    // http://www.drdobbs.com/com-objects-c-and-the-microsoft-speech-a/184416575
    // http://vbcity.com/forums/t/125150.aspx
    // https://people.kth.se/~maguire/DEGREE-PROJECT-REPORTS/050702-Johan_Sverin-with-cover.pdf
    // https://msdn.microsoft.com/en-us/library/ee125471(v=vs.85).aspx
    // https://stackoverflow.com/questions/20770593/speech-to-phoneme-in-net
