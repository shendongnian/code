    public class ImageMap:ClassMap<Image> {
        public ImageMap() {
            Id(x => x.Id);
            References(x => x.ImageGallery);
            Map(x => x.Low);
            Map(x => x.IsActive);
            Where("IsActive = 1");
        }
    }
