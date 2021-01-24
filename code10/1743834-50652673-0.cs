	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		class SelectedGroups<T>
        {
            public readonly IList<T> Choose2; // group to Chose 2 elements from
            public readonly IList<T> Choose1_1; // first group to Chose 1 element from
            public readonly IList<T> Choose1_2; // second group to Chose 1 element from
            public SelectedGroups(IList<T> choose2, IList<T> choose11, IList<T> choose12)
            {
                Choose2 = choose2;
                Choose1_1 = choose11;
                Choose1_2 = choose12;
            }
        }
        static IEnumerable<SelectedGroups<T>> ChooseGroups211<T>(IList<IList<T>> groups)
        {
            for (var i = 0; i < groups.Count; i++)
            {
                var outer = groups[i];
                for (var j = 0; j < groups.Count - 1; j++)
                {
                    if (i == j)
                        continue;
                    var first = groups[j];
                    // start from j+1 so  k > j so groups[k] and groups[j] cover all the groups pairs excactly once
                    for (var k = j + 1; k < groups.Count; k++) 
                    {
                        if (i == k)
                            continue;
                        yield return new SelectedGroups<T>(outer, first, groups[k]); ;
                    }
                }
            }
        }
        public class SelectionResult<T>
        {
            public readonly T Value11; // first value from the group #1
            public readonly T Value12; // second value from the group #1
            public readonly T Value3; // value from the group #2
            public readonly T Value4; // value from the group #3
            public SelectionResult(T value11, T value12, T value3, T value4)
            {
                Value11 = value11;
                Value12 = value12;
                Value3 = value3;
                Value4 = value4;
            }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", Value11, Value12, Value3, Value4);
            }
        }
        static IEnumerable<SelectionResult<T>> Select211FromGroups<T>(SelectedGroups<T> groups)
        {
            for (var i = 0; i < groups.Choose2.Count - 1; i++)
            {
                var value11 = groups.Choose2[i];
                // start from i+1 so  j > i so groups.Choose2[i] and groups.Choose2[j] cover all the pairs excactly once
                for (var j = i + 1; j < groups.Choose2.Count; j++)
                {
                    var value12 = groups.Choose2[j];
                    foreach (var value3 in groups.Choose1_1)
                    {
                        foreach (var value4 in groups.Choose1_2)
                        {
                            yield return new SelectionResult<T>(value11, value12, value3, value4);
                        }
                    }
                }
            }
        }
        public static IEnumerable<SelectionResult<T>> Select211<T>(IList<IList<T>> groups)
        {
            return ChooseGroups211(groups).SelectMany(g => Select211FromGroups(g));
        }
        public static void Main(string[] args)
        {
            //PrintHex(4);
            List<int> g1 = new List<int>() { 1, 2, 3, 4 };
            List<int> g2 = new List<int>() { 7, 8, 9, 10 };
            List<int> g3 = new List<int>() { 15, 16, 17, 18 };
            List<int> g4 = new List<int>() { 22, 23, 24, 25 };
            List<int> g5 = new List<int>() { 27, 28, 29, 30 };
            var allGroups = new List<IList<int>>() { g1, g2, g3, g4, g5 };
            foreach (var selectionResult in Select211(allGroups))
            {
                Console.WriteLine(selectionResult);
            }
        }
	}
