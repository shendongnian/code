    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace TestRecursive2342
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<OutlineObject> outlineObjects = new List<OutlineObject>();
    
                //convert file contents to object collection 
                List<string> lines = Helpers.GetFileAsLines();
    
                Stack<OutlineObject> stack = new Stack<OutlineObject>();
                OutlineObject lastItem = new OutlineObject();
                bool processOk = true;
    
                foreach (var line in lines)
                {
                    OutlineObject oo = new OutlineObject(line);
    
                    if (lastItem.Indent != -1)
                    {
                        if (oo.Indent == 0 && lastItem.Indent != 0)
                        {
                            // we've got a new root node item, so add the last item's top level parent to the list
                            while (lastItem.parent != null)
                                lastItem = lastItem.parent;
    
                            outlineObjects.Add(lastItem);
                        }
                        else if ((oo.Indent - lastItem.Indent) == 1)
                        {
                            // new item is one level lower than the last item
                            oo.parent = lastItem;
                            lastItem.OutlineObjects.Add(oo);
                        }
                        else if (oo.Indent == lastItem.Indent)
                        {
                            // new item is at the same level as the last item
                            oo.parent = lastItem.parent;
                            lastItem.parent.OutlineObjects.Add(oo);
                        }
                        else if ((oo.Indent - lastItem.Indent) < 0)
                        {
                            // new item is above the last item, but not a root node
                            // NB: this only allows for an item to be two levels above the last item
                            oo.parent = lastItem.parent.parent;
                            lastItem.parent.parent.OutlineObjects.Add(oo);
                        }
                        else if ((oo.Indent - lastItem.Indent) > 1)
                        {
                            // missing node check
                            Console.WriteLine("ERROR: missing node in input file between \"{0}\" and \"{1}\"", lastItem.Line, oo.Line);
                            processOk = false;
                            break;
                        }
                    }
    
                    lastItem = oo;
                }
    
                if (processOk)
                {
                    // flush the last item
                    while (lastItem.parent != null)
                        lastItem = lastItem.parent;
    
                    outlineObjects.Add(lastItem);
    
                    outlineObjects.ForEach(oo => oo.Output());
                }
    
                Console.ReadLine();
            }
        }
    
        public class OutlineObject
        {
            public OutlineObject parent { get; set; }
            public List<OutlineObject> OutlineObjects { get; set; }
    
            public string Line { get; set; }
            public int Indent { get; set; }
    
            public void Output()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('-', this.Indent);
                sb.Append(this.Line);
    
                Console.WriteLine(sb);
    
                foreach (OutlineObject oChild in this.OutlineObjects)
                {
                    oChild.Output();
                }
            }
    
            public OutlineObject()
            {
                parent = null;
                OutlineObjects = new List<OutlineObject>();
                Line = "";
                Indent = -1;
            }
    
            public OutlineObject(string rawLine)
            {
                OutlineObjects = new List<OutlineObject>();
                Indent = rawLine.CountPrecedingDashes();
                Line = rawLine.Trim(new char[] { '-', ' ', '\t' });
            }
        }
    
        public static class Helpers
        {
            public static List<string> GetFileAsLines()
            {
                return new List<string> { 
                    "countries", 
                    "-france", 
                    "--paris", 
                    "--bordeaux", 
                    "-germany", 
                    "-italy", 
                    "subjects", 
                    "-math", 
                    "--algebra", 
                    "--calculus", 
                    "-science", 
                    "--chemistry", 
                    "--biology", 
                    "other", 
                    "-this", 
                    "-that"};
            }
    
            public static int CountPrecedingDashes(this string line)
            {
                int tabs = 0;
    
                foreach (var c in line)
                {
                    if (c == '-')
                        tabs++;
                    else
                        break;
                }
                return tabs;
            }
        }
    }
