    public class MyPageViewDataSource : UIPageViewControllerDataSource
    {
    
        List<UIViewController> pageList;
        public MyPageViewDataSource(List<UIViewController> pages)
        {
            pageList = pages;
        }
    
        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {           
            var index = pageList.IndexOf(referenceViewController);
            if (index < pageList.Count - 1)
            {
                return pageList[++index];
            }
            else
            {
                //when navigate to the last page, return null to disable navigate to next.
                return null;
            }
        }
    
        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            var index = pageList.IndexOf(referenceViewController);
            if (index == 0)
            {
                //when navigate to the first page, return null to disable navigate to previous.
                return null;
            }
            else
            {
                return pageList[index - 1];
            }
        }
    }
