    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace NumberLine
    {
        class Program
        {
            static void Main(string[] args)
            {
                NumberLine line = new NumberLine();
                line.AddRange(1, 5);
                line.AddRange(10, 12);
                line.AddRange(20, 30);
    
                List<Range> ranges = line.CheckRange(10, 25);
                foreach (Range r in ranges)
                {
                    for (int i = r.Start; i <= r.End; i++)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    
        class Range
        {
            public int Start;
            public int End;
        }
    
        class NumberLine
        {
            private SortedList<int, Range> Ranges = new SortedList<int, Range>();
    
            public void AddRange(int start, int end)
            {
                if (Ranges.Count == 0)
                {
                     Ranges.Add(start, new Range() { Start = start, End = end });
                }
                else
                {
                    foreach (Range currentRange in Ranges.Values)
                    {
                        if (start <= currentRange.Start) 
                        {
                            if (end >= currentRange.End)
                            {
                                currentRange.Start = start;
                                currentRange.End = end;
                            }
                            else
                            {
                                currentRange.Start = start;
                            }
                            Ranges.RemoveAt(start);
                            Ranges.Add(start, currentRange);
                            break;
                        } 
                        else
                        {
                            if (start <= currentRange.End)
                            {
                                currentRange.End = end;
                                break;
                            }
                            else
                            {
                                Ranges.Add(start, new Range(){ Start = start, End = end });
                                break;
                            }
                        }
                    }           
                }
            }
    
            public List<Range> CheckRange(int start, int end)
            {
                List<Range> result = new List<Range>();
                foreach (Range currentRange in Ranges.Values)
                {
                    if (start <= currentRange.End)
                    {
                        if (end <= currentRange.End)
                        {
                            result.Add(new Range() { Start = currentRange.Start, End = end });
                            break;
                        }
                        else
                        {
                            if (start <= currentRange.Start)
                            {
                                result.Add(new Range() { Start = currentRange.Start, End = currentRange.End });
                            }
                            else
                            {
                                result.Add(new Range() { Start = start, End = currentRange.End });
                            }
                        }
                    }
                }
                return result;
            }
        }
    
    }
