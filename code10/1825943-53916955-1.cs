    sing System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    namespace ConsoleApplication94
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<TagData> list = new List<TagData>() {
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:10:00.000"), Tag = "extrg_01", Value = 1},
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:12:02.000"), Tag = "extrg_01", Value = 1},
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:15:02.000"), Tag = "extrg_01", Value = 0},
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:16:01.000"), Tag = "extrg_01", Value = 0},
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:25:50.000"), Tag = "extrg_01", Value = 1},
                    new TagData() { Timestamp = DateTime.Parse("2018-12-01 00:45:11.000"), Tag = "extrg_01", Value = 0}
                };
                TagData data = new TagData(list);
                foreach(TagData tagData in data)
                {
                    DateTime start = tagData.Timestamp;
                    DateTime end = tagData.Endstamp;
                    double seconds = tagData.numberOfSeconds;
                }
            }
        }
        class TagData : IEnumerator<TagData>
        {
            public DateTime Timestamp { get; set; }
            public string Tag { get; set; }
            public double Value { get; set; }
            public DateTime Endstamp { get; set; }
            public double numberOfSeconds;
            private List<TagData> listData;
            private int curIndex;
            private int endIndex;
            private TagData curTagData;
            public TagData() { }
            public TagData(List<TagData> collection)
            {
                listData = collection;
                curIndex = -1;
                endIndex = -1;
                curTagData = default(TagData);
            }
            public bool MoveNext()
            {
                if (curIndex != -1) curIndex = endIndex;
                while ((++curIndex < listData.Count()) && (listData[curIndex].Value != 1)) { }
                if (curIndex < listData.Count())
                {
                    endIndex = curIndex;
                    while ((endIndex < listData.Count()) && (listData[endIndex].Value != 0)) endIndex++;
                    if (endIndex >= listData.Count()) return false;
                    listData[curIndex].Endstamp = listData[endIndex].Timestamp;
                    listData[curIndex].numberOfSeconds = (listData[curIndex].Endstamp - listData[curIndex].Timestamp).TotalSeconds;
                }
                else
                {
                    return false;
                }
                curTagData = listData[curIndex];
                return true;
            }
            public void Reset() { curIndex = -1; endIndex = -1; }
            void IDisposable.Dispose() { }
            public TagData Current
            {
                get { return curTagData; }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public TagData  GetEnumerator()
            {
                return new TagData(listData);
            }
        }
    }
