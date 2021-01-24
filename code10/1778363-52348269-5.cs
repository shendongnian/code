    internal static IEnumerable<T> MidiEventT<T>(MidiFile midi, int tkid = 0, int max=-1)
      where T : MidiEvent
    {
      int LIMIT = midi.Events[tkid].Count, counter=0;
      if ((max != -1) && (max < LIMIT)) LIMIT = max;
      for (int i = 0; i < midi.Events[tkid].Count; i++)
      {
        if (counter == LIMIT) break;
        T tmsg = midi.Events[tkid][i] as T;
        if (tmsg == null) continue;
        counter++;
        yield return tmsg;
      }
    }
