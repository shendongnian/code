    using System.Linq;
    ... 
    List<InstalledVoice> voices = synthesizer
      .GetInstalledVoices()                                          // all voices
      .Where(voice => voice.VoiceInfo.Culture.Name.StartsWith("es")) // but filtered
      .ToList();                                                     // organized in a list
