List&lt;EmailAddress&gt; list = new List&lt;EmailAddress&gt;();
const int BATCH_SIZE = 50;
         
for (int i = 0; i &lt; list.Count; i += BATCH_SIZE)
{
   IEnumerable&lt;EmailAddress&gt; currentBatch = 
      list.Skip(i).Take(BATCH_SIZE);
            
   // do stuff...
}
