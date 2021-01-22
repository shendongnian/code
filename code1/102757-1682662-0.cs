    public class HomepageCarousel<T> : List<T> where T: IHomepageCarouselItem
    {
    
        private List<T> GetInitialCarouselData()
        {
           List<T> carouselItems = new List<T>();
    
           if (jewellerHomepages != null)
           {
                foreach (PageData pageData in jewellerHomepages)
                {
                    T homepageMgmtCarouselItem = null;
                    homepageMgmtCarouselItem = homepageMgmtCarouselItem.create(pageData);
                    carouselItems.Add(homepageMgmtCarouselItem);
                }
           }
           return carouselItems;
        }
    }
    
    public static class Factory
    {
       someT create(this someT, PageData pageData)
       {
          //implement one for each needed type
       }
    
       object create(this IHomepageCarouselItem obj, PageData pageData)
       {
          //needed to silence the compiler
          throw new NotImplementedException();
       }
    }
