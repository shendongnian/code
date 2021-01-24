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
            static string[] cplFILENAMES = {@"c:\temp\test.xml"};
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
                var groups = (from cpl in CompositionPlayList.dictSequences
                              join asset in AssetMap.dictAsset on cpl.Key equals asset.Key
                              select new { cpl = cpl, asset = asset }).ToList();
            }
        }
        public class CompositionPlayList
        {
            public string filename { get; set; }
            public string id { get; set; }
            public DateTime issueDate { get; set; }
            public string segmentID { get; set; }
            public static Dictionary<string, Sequence> dictSequences = new Dictionary<string, Sequence>();
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
                segmentID = ((string)segment.Element(ns + "Id")).Split(new char[] {':'}).LastOrDefault();
                List<XElement> sequences = segment.Element(ns + "SequenceList").Elements().ToList();
                XNamespace ccNs = sequences.FirstOrDefault().GetNamespaceOfPrefix("cc");
                Dictionary<string, Sequence> newDictSequences = sequences.Select(x => new Sequence
                {
                    sequenceType = x.Name.LocalName,
                    id = ((string)x.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault(),
                    trackID = ((string)x.Element(ns + "TrackId")).Split(new char[] { ':' }).LastOrDefault()
                }).GroupBy(x => x.id, y => y)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (KeyValuePair<string, Sequence> sequence in newDictSequences)
                {
                    dictSequences.Add(sequence.Key, sequence.Value);
                }
            }
        }
        public class Sequence
        {
            public string sequenceType { get; set; }
            public string id { get; set; }
            public string trackID { get; set; }
        }
        public class AssetMap
        {
            public string filename { get; set; }
            public string id { get; set; }
            public DateTime issueDate { get; set; }
            public static Dictionary<string, Asset> dictAsset = new Dictionary<string, Asset>();
            public AssetMap() {}
            public AssetMap(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement assetMap = doc.Root;
                XNamespace ns = assetMap.GetDefaultNamespace();
                this.filename = filename;
                id = ((string)assetMap.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault();
                issueDate = (DateTime)assetMap.Element(ns + "IssueDate");
                List<XElement> assets = assetMap.Element(ns + "AssetList").Elements().ToList();
                Dictionary<string, Asset>  newDictAsset = assets.Select(x => new Asset {
                    id = ((string)x.Element(ns + "Id")).Split(new char[] { ':' }).LastOrDefault()
                }).GroupBy(x => x.id, y => y)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (KeyValuePair<string, Asset> sequence in newDictAsset)
                {
                    dictAsset.Add(sequence.Key, sequence.Value);
                }
            }
        }
        public class Asset
        {
            public string id { get; set; }
        }
    }
