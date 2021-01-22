    System.IO.FileStream fs = 
        new System.IO.FileStream(@"c:\sample.wav", 
        System.IO.FileMode.Append);
    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
    char[] cue = new char[] { 'c', 'u', 'e', ' ' };
    bw.Write(cue, 0, 4); // "cue "
    bw.Write((int)28); // chunk size = 4 + (24 * # of cues)
    bw.Write((int)1); // # of cues
    // first cue point
    bw.Write((int)0); // unique ID of first cue
    bw.Write((int)0); // position
    char[] data = new char[] { 'd', 'a', 't', 'a' };
    bw.Write(data, 0, 4); // RIFF ID = "data"
    bw.Write((int)0); // chunk start
    bw.Write((int)0); // block start
    bw.Write((int)500); // sample offset - in a mono, 16-bits-per-sample WAV
    // file, this would be the 250th sample from the start of the block
    bw.Close();
    fs.Dispose();
