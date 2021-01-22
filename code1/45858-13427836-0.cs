    using System.Collections.Generic;
    public class SiteDataItem
    { 
    private string _text; 
    private string _url; 
    private int _id; 
    private int _parentId;
    public string Text
    {  
        get 
        { 
            return _text; 
        }  
        set 
        { 
            _text = value;
        } 
    }
    public string Url 
    {  
        get 
        { 
            return _url; 
        }  
        set 
        { 
            _url = value;
        } 
    }
    public int ID 
    {  
        get 
        { 
            return _id;
        }  
        set 
        { 
            _id = value;
        } 
    }
    public int ParentID 
    {  
        get 
        { 
            return _parentId;
        } 
        set 
        { 
            _parentId = value;
        } 
    }
    public SiteDataItem(int id, int parentId, string text, string url)
    {  
        _id = id;
        _parentId = parentId;
        _text = text;
        _url = url;
    }
    public static List<SiteDataItem> GetSiteData() 
    {  
        List<SiteDataItem> siteData = new List<SiteDataItem>();
        siteData.Add(new SiteDataItem(1, 0, "All Sites", ""));  
        siteData.Add(new SiteDataItem(2, 1, "Search Engines", ""));
        siteData.Add(new SiteDataItem(3, 1, "News Sites", ""));
        siteData.Add(new SiteDataItem(4, 2, "Yahoo", "http://www.yahoo.com"));
        siteData.Add(new SiteDataItem(5, 2, "MSN", "http://www.msn.com"));  
        siteData.Add(new SiteDataItem(6, 2, "Google", "http://www.google.com"));  
        siteData.Add(new SiteDataItem(7, 3, "CNN", "http://www.cnn.com"));  
        siteData.Add(new SiteDataItem(8, 3, "BBC", "http://www.bbc.co.uk"));  
        siteData.Add(new SiteDataItem(9, 3, "FOX", "http://www.foxnews.com"));
        return siteData; 
    }
    }
