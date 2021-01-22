<pre>int columnOffset=4;
using (StreamReader sr = new StreamReader(inputfile))
using (StreamWriter sw = new StreamWriter(outfile))
{
  string line = sr.ReadLine();
  string[] fields = line.Split('\t');
  if (fields[0]=="Name")
  {
    sw.WriteLine(line);
  }
  else
  {
    StringBuilder outLine = new StringBuilder();
    for(int i=0; i<columnOffset; i++)
    {
      if (fields[i]==String.Empty)
        outLine.Append(fields[i+columnOffset-1]);
      else
        outLine.Append(fields[i]);
      outLine.Append('\t');
    }
    outLine.Length--;
    sw.WriteLine(outLine.ToString());
  }
}
