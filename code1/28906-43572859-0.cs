    public static class Arr
    {
        public static int IndexOf<TElement>(this TElement[] Source, TElement Element)
        {
            for (var i = 0; i < Source.Length; i++)
            {
                if (Source[i].Equals(Element))
                    return i;
            }
            return -1;
        }
        public static TElement[] Add<TElement>(ref TElement[] Source, params TElement[] Elements)
        {
            var OldLength = Source.Length;
            Array.Resize(ref Source, OldLength + Elements.Length);
            for (int j = 0, Count = Elements.Length; j < Count; j++)
                Source[OldLength + j] = Elements[j];
            return Source;
        }
        public static TElement[] New<TElement>(params TElement[] Elements)
        {
            return Elements ?? new TElement[0];
        }
        public static void Remove<TElement>(ref TElement[] Source, params TElement[] Elements)
        {
            foreach (var i in Elements)
                RemoveAt(ref Source, Source.IndexOf(i));
        }
        public static void RemoveAt<TElement>(ref TElement[] Source, int Index)
        {
            var Result = new TElement[Source.Length - 1];
            if (Index > 0)
                Array.Copy(Source, 0, Result, 0, Index);
            if (Index < Source.Length - 1)
                Array.Copy(Source, Index + 1, Result, Index, Source.Length - Index - 1);
            Source = Result;
        }
    }
