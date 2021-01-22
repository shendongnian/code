    class NameComparer : IComparer<Name>
    {
        public int Compare(Name x, Name y) { 
            return x.First.CompareTo(y.First); 
        }
    }
    ...
    ...
    var comparer = new NameComparer();
    var david = new Name { First = "David" };
    int guess = list.BinarySearch(david, comparer);
    int start, end;
    start = list.FindLastIndex(guess, person => person.First != "David") + 1;
    if (start > 0 && list[start].First == "David") {
        end = list.FindIndex(guess, person => person.First != "David");
        list.RemoveRange(start, end - start);
    }
