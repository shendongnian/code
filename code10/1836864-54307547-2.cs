    return Ids.AsParallel()
       .Select((id, index) => (id, index))
       .GroupBy(x => x.index%Environment.ProcessorCount, x => x.id, (k, g) => g)
       .Select(g => 
       {
           var sb = new StringBuilder();
           foreach (var id in g)
           {
               sb.Append("<Row");
               sb.Append(" ID='" + id.dataId + "'");
               sb.Append("></Row>");
           }
           return sb.ToString();
       })
       .AsSequential()
       .Aggregate(new StringBuilder("<ROOT>"), (a, b) => a.Append(b))
       .Append("</ROOT>").ToString();
