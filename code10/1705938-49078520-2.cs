    public class TemplateSection {
        public string SectionName { get; set; }
        public List<MyTemplateItem> MyTemplateItems { get; set; }
    
        public static explicit operator Section(TemplateSection src) {
            return new Section {
                SectionName = src.SectionName,
                MyItems = new List<MyItem>(src.MyTemplateItems.Cast<MyItem>())
            };
        }
    }
    
    public class MyTemplateItem {
        public string ItemName { get; set; }
        public string ItemText { get; set; }
    
        public static explicit operator MyItem(MyTemplateItem src) {
            return new MyItem {
                ItemName = src.ItemName,
                ItemText = src.ItemText
            };
        }
    }
