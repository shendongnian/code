    // Setting up credentials
    string jsonPath = @"D:\my-test-project-0078ca7c0f8c.json";
    var credential = GoogleCredential.FromFile(jsonPath).CreateScoped(TextToSpeechClient.DefaultScopes);
    var channel = new Grpc.Core.Channel(TextToSpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
    // Instantiate a client
    TextToSpeechClient client = TextToSpeechClient.Create(channel);
    // Perform the Text-to-Speech request, passing the text input with the selected voice parameters and audio file type 
    var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
    {
        Input = new SynthesisInput() { Text = "My test sentence" },
        Voice = new VoiceSelectionParams() { LanguageCode = "en-US", SsmlGender = SsmlVoiceGender.Male },
        AudioConfig = new AudioConfig { AudioEncoding = AudioEncoding.Mp3 };
    });
