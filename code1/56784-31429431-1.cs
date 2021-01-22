        //! Get subset of collection between \a start and \a end, inclusive
        //! Usage
        //! \code
        //! using ExtensionMethods;
        //! ...
        //! var subset = MyList.GetRange(firstItem, secondItem);
        //! \endcode
    class ExtensionMethods
    {
        public static IEnumerable<T> GetRange<T>(this IEnumerable<T> source, T start, T end)
        {
    #if DEBUG
            if (source.ToList().IndexOf(start) > source.ToList().IndexOf(end))
                throw new ArgumentException("Start must be earlier in the enumerable than end, or both must be the same");
    #endif
            yield return start;
            if (start.Equals(end))
                yield break;                                                    //start == end, so we are finished here
            using (var e = source.GetEnumerator())
            { 
                while (e.MoveNext() && !e.Current.Equals(start));               //skip until start                
                while (!e.Current.Equals(end) && e.MoveNext())                  //return items between start and end
                    yield return e.Current;
            }
        }
    }
