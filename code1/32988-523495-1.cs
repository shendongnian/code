    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    static class Program
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <photos_GetAlbums_response
        xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
        xsi:schemaLocation=""http://api.xxx.com/1.0/ http://api.xxx.com/1.0/xxx.xsd""
        list=""true"">
    <album>
     <aid>3231990241086938677</aid>
     <cover_pid>7031990241087042549</cover_pid>
     <owner>1337262814</owner>
     <name>LA</name>
     <created>1233469624</created>
     <modified>1233469942</modified>
     <description>trip to LA</description>
     <location>CA</location>
     <link>http://www.xxx.com/album.php?aid=7333&amp;id=1337262814</link>
     <size>48</size>
     <visible>friends</visible>
     </album>
    <album>
     <aid>7031990241086936240</aid>
     <cover_pid>7031990241087005994</cover_pid>
     <owner>1337262814</owner>
     <name>Wall Photos</name>
     <created>1230437805</created>
     <modified>1233460690</modified>
     <description/>
     <location/>
     <link>http://www.xxx.com/album.php?aid=3296&amp;id=1337262814</link>
     <size>34</size>
     <visible>everyone</visible>
     </album>
    <album>
     <aid>7031990241086937544</aid>
     <cover_pid>7031990241087026027</cover_pid>
     <owner>1337262814</owner>
     <name>Mobile Uploads</name>
     <created>1231984989</created>
     <modified>1233460349</modified>
     <description/>
     <location/>
     <link>http://www.xxx.com/album.php?aid=6300&amp;id=1337262814</link>
     <size>3</size>
     <visible>friends</visible>
     </album>
    <album>
     <aid>7031990241086936188</aid>
     <cover_pid>7031990241087005114</cover_pid>
     <owner>1337262814</owner>
     <name>Christmas 2008</name>
     <created>1230361978</created>
     <modified>1230362306</modified>
     <description>My Album</description>
     <location/>
     <link>http://www.xxx.com/album.php?aid=5234&amp;id=1337262814</link>
     <size>50</size>
     <visible>friends</visible>
     </album>
    <album>
     <aid>7031990241086935881</aid>
     <cover_pid>7031990241087001093</cover_pid>
     <owner>1637262814</owner>
     <name>Hock</name>
     <created>1229889219</created>
     <modified>1229889235</modified>
     <description>Misc Pics</description>
     <location/>
     <link>http://www.xxx.com/album.php?aid=4937&amp;id=1637262814</link>
     <size>1</size>
     <visible>friends-of-friends</visible>
     </album>
    <album>
     <aid>7031990241086935541</aid>
     <cover_pid>7031990241086996817</cover_pid>
     <owner>1637262814</owner>
     <name>Test Album 2 (for work)</name>
     <created>1229460455</created>
     <modified>1229460475</modified>
     <description>this is a test album</description>
     <location/>
     <link>http://www.xxx.com/album.php?aid=4547&amp;id=1637262814</link>
     <size>1</size>
     <visible>everyone</visible>
     </album>
    <album>
     <aid>7031990241086935537</aid>
     <cover_pid>7031990241086996795</cover_pid>
     <owner>1637262814</owner>
     <name>Test Album (for work)</name>
     <created>1229459168</created>
     <modified>1229459185</modified>
     <description>Testing for work</description>
     <location/>
     <link>http://www.xxx.com/album.php?aid=4493&amp;id=1637262814</link>
     <size>1</size>
     <visible>friends</visible>
     </album>
     </photos_GetAlbums_response>";
        static void Main()
        {
            XmlSerializer ser = new XmlSerializer(typeof(GetAlbumsResponse));
            GetAlbumsResponse response;
            using (StringReader reader = new StringReader(xml))
            {
                response = (GetAlbumsResponse)ser.Deserialize(reader);
            }
    
        }
    }
    
    [Serializable, XmlRoot("photos_GetAlbums_response")]
    public class GetAlbumsResponse
    {
        [XmlElement("album")]
        public List<Album> Albums {get;set;}
    
        [XmlAttribute("list")]
        public bool IsList { get; set; }
    }
    public enum AlbumVisibility
    {
        [XmlEnum("")]
        None,
        [XmlEnum("friends")]
        Friends,
        [XmlEnum("friends-of-friends")]
        FriendsOfFriends,
        [XmlEnum("everyone")]
        Everyone
    
    }
    [Serializable]
    public class Album
    {
        static readonly DateTime epoch = new DateTime(1970, 1, 1);
        static long SerializeDateTime(DateTime value)
        {
            return (long)((value - epoch).TotalSeconds);
        }
        static DateTime DeserializeDateTime(long value)
        {
            return epoch.AddSeconds(value);
        }
        [XmlElement("aid")]
        public long AlbumID { get; set; }
    
        [XmlElement("cover_pid")]
        public long CoverPhotoID { get; set; }
    
        [XmlElement("owner")]
        public long Owner { get; set; }
    
        [XmlElement("name")]
        public string AlbumName { get; set; }
    
        [XmlIgnore]
        public DateTime CreateDate { get; set; }
    
        [XmlElement("created"), Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long CreateDateInt64 {
            get {return SerializeDateTime(CreateDate);}
            set {CreateDate = DeserializeDateTime(value);}
        }
    
        [XmlIgnore]
        public DateTime LastModifiedDate { get; set; }
    
        [XmlElement("modified"), Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long LastModifiedDateInt64
        {
            get { return SerializeDateTime(LastModifiedDate); }
            set { LastModifiedDate = DeserializeDateTime(value); }
        }
    
        [XmlElement("description")]
        public string Description { get; set; }
    
        [XmlElement("location")]
        public string Location { get; set; }
    
        [XmlElement("link")]
        public string Link { get; set; }
    
        [XmlElement("size")]
        public int Size { get; set; }
    
        [XmlElement("visible")]
        public AlbumVisibility Visibility { get; set; }
    }
