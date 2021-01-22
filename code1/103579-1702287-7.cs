    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace TestInstant
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> pageItemsIdCodes = new List<string>();
                pageItemsIdCodes.Add("PageItem1");
                pageItemsIdCodes.Add("PageItem2");
                PageItemManager pageItemManager = new PageItemManager(pageItemsIdCodes);
                pageItemManager.DisplayMenu();
    
                Console.ReadLine();
            }
        }
    
        class PageItemManager
        {
            private Dictionary<string, BasePageItem> PageItemRecords = new Dictionary<string, BasePageItem>();
            public PageItemManager(List<string> pageItemsIdCodes)
            {
                //manually
                //PageItemRecords.Add("PageItem1", new PageItem1(this));
                //PageItemRecords.Add("PageItem2", new PageItem2(this));
    
                foreach (string pageItemIdCode in pageItemsIdCodes)
                {
                    Type t = Type.GetType("TestInstant."+pageItemIdCode);
                    BasePageItem pageItem = (BasePageItem)Activator.CreateInstance(t, new Object[] { this });
                    PageItemRecords.Add(pageItemIdCode, pageItem);
                }
    
            }
    
            public void DisplayMenu()
            {
                foreach (BasePageItem pageItemRecord in PageItemRecords.Values)
                {
                    Console.WriteLine(pageItemRecord.Title);
                }
            }
        }
    
        class BasePageItem
        {
            private string mTitle;
            public string Title { get { return mTitle; } set { mTitle = value; } }
            protected PageItemManager pageItemManager;
            public BasePageItem(PageItemManager pageItemManager)
            {
                this.pageItemManager = pageItemManager;
            }
        }
    
        class PageItem1 : BasePageItem
        {
            public PageItem1(PageItemManager pageItemManager)
                : base(pageItemManager)
            {
                Title = "This is page one.";
            }
        }
    
        class PageItem2 : BasePageItem
        {
            public PageItem2(PageItemManager pageItemManager)
                : base(pageItemManager)
            {
                Title = "This is page two.";
    
            }
        }
    }
