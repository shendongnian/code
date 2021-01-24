            var resultList = new List<IContent>();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            foreach (ContentAreaItem contentAreaItem in currentPage.PrimaryComponentArea.FilteredItems)
            {
                if (contentAreaItem != null && contentAreaItem.ContentLink != null &&
                    contentAreaItem.ContentLink != ContentReference.EmptyReference)
                {
                
                IContent content;
                if (contentLoader.TryGet(contentAreaItem.ContentLink, out content))
                    if (content != null)
                    {
                        resultList.Add(content);
                    }
                }
            }
