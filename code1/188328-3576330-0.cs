    TTSServiceClient aClient = new TTSServiceClient(); 
    UnSerializableObject loMMessage = new MostMessage();
    SerializableObject loSMMessage = new SerializableObject();
    loSMMessage.Item1 = loMMessage.Item1;
    aClient.Allocate_OnStartResultAck(loSMMessage);
