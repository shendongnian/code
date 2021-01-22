    public class HomepageCarousel<T> : List<T>
        where T: IHomepageCarouselItem, new()
    {
        private readonly List<PageData> jewellerHomepages;
        public class HomepageCarousel(List<PageData> jewellerHomepages)
        {
            this.jewellerHomepages = jewellerHomepages;
            this.AddRange(GetInitialCarouselData());
        }
        // ...
    }
