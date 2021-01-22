    public static IEnumerable<Foo> TakeVoices(
        this IEnumerable<Foo> voices, int needed)
    {
        int count = 0;
        foreach (Foo voice in voices)
        {
            if (count >= needed) yield break;
            yield return voice;
            count += voice.Voices;
        }
    }
    ....
    foreach(var voice in sample.TakeVoices(numberNeeded)) {
        ...
    }
