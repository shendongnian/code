theWriter.Close();
theStream.Position = 0; // So you can start reading from the begining
string xml = null;
using (StringReader read = new StringReader(theStream))
{
   xml = read.ReadToEnd();
}
</pre>
