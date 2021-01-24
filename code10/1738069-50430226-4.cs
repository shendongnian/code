    class Program
    {
        public class Entry
        {
            public string MachineNr { get; set; }
            public string ControlDone { get; set; }
            public int Count { get; set; }
            public List<string> Items { get; set; }
            private static IEnumerable<string> fields(string list)
            {
                int idx = 0;
                do
                {
                    int ndx = list.IndexOf('|', idx);
                    if (ndx == 1)
                        yield return list.Substring(idx);
                    else
                        yield return list.Substring(idx, ndx - idx);                        
                    idx = ++ndx;
                }
                while (idx > 0 && idx < list.Length-1) ;
            }
            
            public static IEnumerable<Entry> parseList(string list)
            {
                int idx =0;
                var fields = Entry.fields(list).GetEnumerator();
                while (fields.MoveNext())
                {
                    var e = new Entry();
                    e.MachineNr = fields.Current;
                    if (fields.MoveNext())
                    {
                        e.ControlDone = fields.Current;
                        if (fields.MoveNext())
                        {
                            int val = 0;
                            e.Count = int.TryParse(fields.Current, out val) ? val : 0;
                            e.Items = new List<string>();
                            for (int x=e.Count;x>0;x--)
                            {
                                if (fields.MoveNext())
                                    e.Items.Add(fields.Current);
                            }
                        }
                    }
                    yield return e;
                }
            }
        }
        static void Main(string[] args)
        {
            string strTargetString = @"446408|0|1|111|446408|0|3|99884|111|73732|446408|0|0||";
            foreach (var entry in Entry.parseList(strTargetString))
            {
                Console.WriteLine(
    $@"Group:
        Machine:        {entry.MachineNr}
        ControlDone:    {entry.ControlDone}
        Count:          {entry.Count}
        Items:          {string.Join(", ",entry.Items)}");
            }
        }
    }
