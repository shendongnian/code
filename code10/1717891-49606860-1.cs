    private int _bufferSize;
    private AudioTrack _output;
    // in constructor
    _bufferSize = AudioTrack.GetMinBufferSize(8000, ChannelOut.Mono, Encoding.Pcm16bit);
    // when starting to play audio
    _output = new AudioTrack(Stream.Music, 8000, ChannelOut.Mono, Encoding.Pcm16bit, _bufferSize, AudioTrackMode.Stream);
    _output.Play();
    // when data arrives via UDP socket
    byte[] decoded = _codec.Decode(decrypted, 0, decrypted.Length);                
    // just write to AudioTrack
    _output.Write(decoded, 0, decoded.Length);
   
