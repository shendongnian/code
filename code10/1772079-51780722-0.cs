    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                List<int> signals = new List<int>() { 680, 841, 154, 940, 160, 157, 936, 354, 363,  682, 871, 932, 845, 32};
    
                signals.Sort();
    
                List<GapData> gapsData = new List<GapData>();
    
                for(int i = 0; i < signals.Count - 1; i++)
                {
                    GapData newGap = new GapData() { Index = i, Span = signals[i + 1] - signals[i] };
                    gapsData.Add(newGap);
                }
    
                gapsData.Sort();
    
                gapsData = gapsData.Take(5).ToList(); //Keep 5 biggest gaps
    
                gapsData = gapsData.OrderBy(i => i.Index).ToList(); //sort on index
                
                List<List<int>> groupedList = new List<List<int>>();
    
                int index = 0;
    
                List<int> currentGroup = new List<int>();
                groupedList.Add(currentGroup);
    
                for(int i = 0; i < signals.Count; i++)
                {
                    if (index < 5 && gapsData[index].Index < i)
                    {
                        currentGroup = new List<int>();
                        groupedList.Add(currentGroup);
                        index++;
                    }
                    currentGroup.Add(signals[i]);
                }
            }
    
     
            public class GapData:IComparable<GapData>
            {
                public GapData()
                {
                }
                public int Index { get; set; }
    
                public int CompareTo(GapData other)
                {
                    return - Span.CompareTo(other.Span);
                }
            
    
                public int Span { get; set; }
            }
        }
    
    }
