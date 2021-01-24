    public partial class ColoredTableView : TableView
       {
           public static BindableProperty GroupHeaderColorProperty = BindableProperty.Create("GroupHeaderColor", typeof(Color), typeof(ColoredTableView), Color.White);
           public Color GroupHeaderColor
           {
               get
               {
                   return (Color)GetValue(GroupHeaderColorProperty);
               }
               set
               {
                   SetValue(GroupHeaderColorProperty, value);
               }
           }
     
           public ColoredTableView()
           {
               InitializeComponent();
           }
       }
