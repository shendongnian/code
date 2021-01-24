    class Program
    {
      static void Main( string[ ] args )
      {
        using ( var connection = new SqlConnection( "Data Source=.;Initial Catalog=...;Integrated Security=True" ) )
        {
          connection.Open( );
          var serverConnection = new ServerConnection( connection );
          var server = new Server( serverConnection );
          var db = server.Databases[ "..." ];
          var objects = new UrnCollection( );
          foreach ( Table table in db.Tables )
          {
            objects.Add( table.Urn );
          }
          var dependency = new DependencyWalker( server );
          var tree = dependency.DiscoverDependencies( objects, DependencyType.Parents );
          Walk( tree.FirstChild );
        }
      }
    
      static void Walk( DependencyTreeNode node, int depth = 0 )
      {
        Print( node.Urn, depth );
        if ( node.HasChildNodes )
        {
          Walk( node.FirstChild, depth + 1 );
        }
        if ( node.NextSibling != null )
        {
          Walk( node.NextSibling, depth );
        }
      }
    
      static void Print( string message, int depth )
      {
        var space = string.Empty;
        for ( int i = 0; i < depth; i++ ) space += " ";
        Debug.WriteLine( string.Format( "{0}{1}", space, message ) );
      }
    }
