    public partial class ListBoxWithBg : ListBox
    {
       Image image;
       
       public ListBoxWithBg()
       {
           InitializeComponent();
           this.DrawMode = DrawMode.OwnerDrawVariable;
           this.DrawItem += new DrawItemEventHandler(ListBoxWithBg_DrawItem);
           this.image = Image.FromFile("C:\\some-image.bmp");
       }
       void ListBoxWithBg_DrawItem(object sender, DrawItemEventArgs e)
       {
           e.DrawBackground();
           e.DrawFocusRectangle();
           e.Graphics.DrawImage(this.image, new Point(0, 0));
       }
    }
