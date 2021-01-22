string[] linesOfMimeTypes = File.ReadAllLines("mime.types");
List&lt;string> mimeTypes = new List&lt;string>();
foreach( string line in linesOfMimeTypes )
{
    if( line.length &lt; 1 )
        continue;
    if( line[0] == '#' )
        continue;
    // else:
    mimeTypes.Add( line.Split( new char[] { ' ', '\t' } )[0] );
}
if( mimeTypes.Contains( oneToTest ) )
{
    // hooray!
}
