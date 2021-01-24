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
            static string[] cplFILENAMES = { @"c:\temp\test.xml" };
            static string[] assetFILENAMES = { @"c:\temp\test1.xml" };
            static void Main(string[] args)
            {
                foreach (string filename in cplFILENAMES)
                {
                    new CompositionPlayList(filename);
                }
                foreach (string filename in assetFILENAMES)
                {
                    new AssetMap(filename);
                }
                var groups = (from cpl in CompositionPlayList.sequences
                              join asset in AssetMap.assets on cpl.trackID equals asset.id into a
                              from asset in a.DefaultIfEmpty()
                              select new { id = cpl.id, cpl = cpl.trackID, asset = asset}).ToList();
            }
        }
        public class CompositionPlayList
        {
            public string filename { get; set; }
            public string id { get; set; }
            public DateTime issueDate { get; set; }
            public string segmentID { get; set; }
            public static List<Sequence> sequences = new List<Sequence>();
            public CompositionPlayList() { }
            public CompositionPlayList(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement cpl = doc.Root;
                XNamespace ns = cpl.GetDefaultNamespace();
                this.filename = filename;
                id = ((string)cpl.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault();
                issueDate = (DateTime)cpl.Element(ns + "IssueDate");
                XElement segment = cpl.Descendants(ns + "Segment").FirstOrDefault();
                segmentID = ((string)segment.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault();
                List<XElement> sequences = segment.Element(ns + "SequenceList").Elements().ToList();
                XNamespace ccNs = sequences.FirstOrDefault().GetNamespaceOfPrefix("cc");
                List<Sequence> newSequences = sequences.Select(x => new Sequence {
                    sequenceType = x.Name.LocalName,
                    id = ((string)x.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault(),
                    trackID = ((string)x.Element(ns + "TrackId")).Split(new char[] { ':' }).LastOrDefault(),
                    filename = filename
                }).ToList();
                CompositionPlayList.sequences.AddRange(newSequences);
            }
        }
        public class Sequence
        {
            public string sequenceType { get; set; }
            public string id { get; set; }
            public string trackID { get; set; }
            public string filename { get; set; }
        }
        public class AssetMap
        {
            public string filename { get; set; }
            public string id { get; set; }
            public DateTime issueDate { get; set; }
            public static List<AssetMap> assets = new List<AssetMap>();
            public AssetMap() { }
            public AssetMap(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement assetMap = doc.Root;
                XNamespace ns = assetMap.GetDefaultNamespace();
                this.filename = filename;
                id = ((string)assetMap.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault();
                issueDate = (DateTime)assetMap.Element(ns + "IssueDate");
                List<XElement> assets = assetMap.Element(ns + "AssetList").Elements().ToList();
                List<AssetMap> newAssets = assets.Select(x => new AssetMap() { id = ((string)x.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault(), filename = filename, issueDate = issueDate }).ToList();
                AssetMap.assets.AddRange(newAssets);
            }
        }
     
    }
