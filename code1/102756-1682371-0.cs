       T factoryDummy = new T();
       List<T> carouselItems = new List<T>();
       if (jewellerHomepages != null)
       {
            foreach (PageData pageData in jewellerHomepages)
            {
                T homepageMgmtCarouselItem = (T)factoryDummy.Construct(pageData);
                carouselItems.Add(homepageMgmtCarouselItem);
            }
       }
       return carouselItems;
