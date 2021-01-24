    using System;
    using System.Collections.Generic;
        
    namespace ee
    {
        public class Core
        {
            
            public static void Main()
            {
                GroupSorter gs = new GroupSorter();
                gs.GroupCorrect();
    
            }
    
        }
    
    
        public class GroupSorter
        {
            List<Rectangle> sentences = new List<Rectangle>();
            List<List<Rectangle>> groupedsentences = new List<List<Rectangle>>();
    
            public GroupSorter()
            {
                Random recBottom = new Random();
                for (int i = 0; i < 100; i++)
                {
                    sentences.Add(new Rectangle() { Bottom = recBottom.Next(10) });
                }
            }
    
            public void GroupCorrect()
            {
                List<Rectangle> copysentences = new List<Rectangle>(sentences);
                copysentences.Sort();
    
                List<Rectangle> lastGroup = null;
                bool createGroup = true;
    
                foreach (Rectangle r in copysentences)
                {
                    if (lastGroup != null)
                    {
                        Rectangle compRec = lastGroup[0]; //Get last group, first element
                        createGroup = (compRec.CompareTo(r) != 0); //BottomRec not equal so new group
                    }
    
                    if (createGroup)
                    {
                        lastGroup = new List<Rectangle>();
                        groupedsentences.Add(lastGroup);
                    }
                    lastGroup.Add(r);
    
                }
    
            }
    
    
        }
    
        public class Rectangle: IComparable<Rectangle>
        {
            public Rectangle()
            { }
            public int Bottom { get; set; }
    
            public int CompareTo(Rectangle other)
            {
                return Bottom.CompareTo(other.Bottom);
            }
        }
    }
