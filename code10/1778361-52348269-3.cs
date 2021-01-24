    class NewTempo
    {
      public long PulseMin, PulseMax;
      public double Seconds, Tempo;
      public bool Match(MidiEvent pnote) {
        return (pnote.AbsoluteTime >= PulseMin) && (pnote.AbsoluteTime < PulseMax);
      }
    }
