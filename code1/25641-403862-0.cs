    class DocumentInfo {
        Dictionary<int, Collection<Rectangle>> rectangles = ...
        public Collection<Rectangle> GetRectangles(int index) {
            return rectangles[index]; // might want to clone to
                                      // protect against mutation
        }
        Dictionary<int, PageInfo> pages = ...
        public PageInfo GetPageInfo(int index) {
            return pages[index];
        }
     }
