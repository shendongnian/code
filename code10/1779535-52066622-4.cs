    public class CustomerRectangle 
    {
        public Rectangle Rect { get; set; }
        public string Name { get; set; }
        public CustomerRectangle(int llx, int lly, int urx, int ury,string name) 
        {
            Rect = new Rectangle(llx, lly, urx, ury);
            Name = name;
        }
    }
