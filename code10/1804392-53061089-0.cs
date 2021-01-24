    namespace TreeViewMultipleRenderers
    {
        public class MainWindowView: Gtk.Window
        {
            public MainWindowView()
                : base( Gtk.WindowType.Toplevel )
            {
                this.SetGeometryHints( this,
                                      new Gdk.Geometry { MinHeight = 400, MinWidth = 600 },
                                      Gdk.WindowHints.MinSize );
                
                this.Build();
            }
    
            void BuildIcons()
            {
                this.IconYes = new Gdk.Pixbuf(
                    System.Reflection.Assembly.GetEntryAssembly(),
                    "TreeViewMultipleRenderers.Res.yes.png", 16, 16 );
    
                this.IconNo = new Gdk.Pixbuf(
                    System.Reflection.Assembly.GetEntryAssembly(),
                    "TreeViewMultipleRenderers.Res.no.png", 16, 16 );
            }
    
            Gtk.TreeView BuildTreeView()
            {
                var toret = new Gtk.TreeView();
    
                // Index column
                var columnIndex = new Gtk.TreeViewColumn {
                    Title = "#"
                };
    
                var indexRenderer = new Gtk.CellRendererText();
                columnIndex.PackStart( indexRenderer, expand: true );
                columnIndex.AddAttribute( indexRenderer, "text", 0 );
    
                // Data column
                var columnData = new Gtk.TreeViewColumn {
                    Title = "Mixed column"
                };
    
                var dataRenderer1 = new Gtk.CellRendererPixbuf();
                columnData.PackStart( dataRenderer1, expand: false );
                columnData.AddAttribute( dataRenderer1, "pixbuf", 1 );
    
                var dataRenderer2 = new Gtk.CellRendererText();
                columnData.PackStart( dataRenderer2, expand: true );
                columnData.AddAttribute( dataRenderer2, "text", 2 );
    
                toret.AppendColumn( columnIndex );
                toret.AppendColumn( columnData );
    
                // Model
                var store = new Gtk.ListStore( typeof( string ), typeof( Gdk.Pixbuf ), typeof( string ) );
                toret.Model = store;
    
                store.AppendValues( "1", this.IconYes, "works" );
                store.AppendValues( "2", this.IconNo, "does not work" );
    
                return toret;
            }
            
            void Build()
            {
                this.BuildIcons();
    
                this.TreeView = this.BuildTreeView();
    
                this.Add( this.TreeView );
            }
            
            public Gtk.TreeView TreeView {
                get; set;
            }
    
            public Gdk.Pixbuf IconYes {
                get; private set;
            }
    
            public Gdk.Pixbuf IconNo {
                get; private set;
            }
        }
    }
