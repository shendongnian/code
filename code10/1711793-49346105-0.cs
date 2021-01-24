    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static string[] FILENAMES = {@"c:\temp\test.xml"};
            static void Main(string[] args)
            {
                foreach (string filename in FILENAMES)
                {
                    new CompositionPlayList(filename);
                }
            }
        }
        public class CompositionPlayList
        {
            public static List<CompositionPlayList> lists = new List<CompositionPlayList>();
            public string filename { get; set; }
            public string id { get; set; }
            public DateTime issueDate { get; set; }
            public string segmentID { get; set; }
            public Dictionary<string, Sequence> dictSequences = new Dictionary<string, Sequence>();
            public CompositionPlayList() { }
            public CompositionPlayList(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement cpl = doc.Root;
                XNamespace ns = cpl.GetDefaultNamespace();
                CompositionPlayList.lists.Add(this);
                this.filename = filename;
                id = ((string)cpl.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault();
                issueDate = (DateTime)cpl.Element(ns + "IssueDate");
                XElement segment = cpl.Descendants(ns + "Segment").FirstOrDefault();
                segmentID = ((string)segment.Element(ns + "Id")).Split(new char[] {':'}).LastOrDefault();
                List<XElement> sequences = segment.Element(ns + "SequenceList").Elements().ToList();
                XNamespace ccNs = sequences.FirstOrDefault().GetNamespaceOfPrefix("cc");
                dictSequences = sequences.Select(x => new Sequence {
                    sequenceType = x.Name.LocalName,
                    id = ((string)x.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault(),
                    trackID = ((string)x.Element(ns + "TrackId")).Split(new char[] { ':' }).LastOrDefault()
                }).GroupBy(x => x.id, y => y)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class Sequence
        {
            public string sequenceType { get; set; }
            public string id { get; set; }
            public string trackID { get; set; }
        }
    }
