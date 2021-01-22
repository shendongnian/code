    public class HomepageCarousel<T> : List<T> where T: IHomepageCarouselItem
    {
        private readonly Func<PageData, T> factory;
        public HomepageCarousel(Func<PageData, T> factory)
        {
            this.factory = factory;
        }
        private List<T> GetInitialCarouselData()
        {
           List<T> carouselItems = new List<T>();
        
           if (jewellerHomepages != null)
           {
                foreach (PageData pageData in jewellerHomepages)
                {
                    T homepageMgmtCarouselItem = factory(pageData);
                    carouselItems.Add(homepageMgmtCarouselItem);
                }
           }
           return carouselItems;
        }
