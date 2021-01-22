    public class Announcement : //..
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public AnnouncementCategory Category { get; set; }
        public string Body { get; set; }
        public LazyItem<Image> Image { get; set; }
        public LazyItem<PdfDoc> PdfDoc { get; set; }
    }
