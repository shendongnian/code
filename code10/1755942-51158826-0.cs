    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Enter the Old Text");
            string oldText = Console.ReadLine();
            Console.WriteLine("Enter the New Text");
            string newText = Console.ReadLine();
            Console.WriteLine("Enter the Caret Position");
            int caretPos = int.Parse(Console.ReadLine());
            Sequence removed = GetRemovedCharacters(oldText, newText, caretPos);
            if(removed != null)
                oldText = oldText.Remove(removed.StartIndex, removed.Length);
            Sequence added = GetAddedCharacters(oldText, newText, caretPos);
            if(added != null)
                oldText = oldText.Insert(added.StartIndex, newText.Substring(added.StartIndex, added.Length));
            Console.WriteLine("Worked: " + (oldText == newText).ToString());
            Console.ReadKey();
            Console.Clear();
        }
    }
    static Sequence GetRemovedCharacters(string oldText, string newText, int caretPosition)
    {
        int startIndex = GetStartIndex(oldText, newText);
        if(startIndex != -1)
        {
            Sequence sequence = new Sequence(startIndex, caretPosition + (oldText.Length - newText.Length) - 1);
            if(SequenceValid(sequence))
                return sequence;
        }
        return null;
    }
    static Sequence GetAddedCharacters(string oldText, string newText, int caretPosition)
    {
        int startIndex = GetStartIndex(oldText, newText);
        if(startIndex != -1)
        {
            Sequence sequence = new Sequence(GetStartIndex(oldText, newText), caretPosition - 1);
            if(SequenceValid(sequence))
                return sequence;
        }
        return null;
    }
    static int GetStartIndex(string oldText, string newText)
    {
        for(int i = 0; i < Math.Max(oldText.Length, newText.Length); i++)
            if(i >= oldText.Length || i < newText.Length || oldText[i] != newText[i])
                return i;
        return -1;
    }
    static bool SequenceValid(Sequence sequence)
    {
        return sequence.StartIndex >= 0 && sequence.EndIndex >= 0 && sequence.EndIndex >= sequence.StartIndex;
    }
