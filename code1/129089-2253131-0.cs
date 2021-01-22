    using System;
    using System.Collections;
    using System.IO;
    using System.Xml.Serialization;
    
    public class MyClass
    {
        public static void RunSnippet()
        {
            var _tabs = new ArrayList();
    
            _tabs.Add(new tsgClsTab(1));
            _tabs.Add(new tsgClsTab(2));
            _tabs.Add(new tsgClsTab(3));
            _tabs.Add(new tsgClsTab(4));
    
            lock ((_tabs))
            {
                StreamReader sr = null;
                MemoryStream ms = null;
                try
                {
                    var srl = new XmlSerializer(typeof (ArrayList),
                                                new Type[] {typeof (tsgClsTab)});
                    ms = new MemoryStream();
                    srl.Serialize(ms, _tabs);
                    ms.Seek(0, 0);
                    sr = new StreamReader(ms);
                    Console.WriteLine(sr.ReadToEnd());
                }
                finally
                {
                    if (((sr != null)))
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                    if (((ms != null)))
                    {
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
    
        #region Nested type: tsgClsTab
    
        public class tsgClsTab
        {
            public tsgClsTab()
            {
            }
    
            public tsgClsTab(int id)
            {
                Id = id;
            }
    
            public int Id { get; set; }
        }
    
        #endregion
    }
