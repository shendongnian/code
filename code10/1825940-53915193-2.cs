	var summaries =
		list.GroupBy(tagdata => tagdata.Tag) // Step (1)
		.Select(group => // Step (2)
		{
			var data = group
		  		.SkipWhile(tagdata => tagdata.Value == 0) // Step (2.1)
				.Aggregate(new List<TagData>(), (acc, tagdata) => // Step (2.2)
				{
				  if (acc.LastOrDefault()?.Value != tagdata.Value)
					  acc.Add(tagdata);
				  return acc;
				});
			
			var ones = data.Where(datatag => datatag.Value == 1);
			var zeros = data.Where(datatag => datatag.Value == 0);
			var result = ones.Zip(zeros, (startTag, endTag) => { // Step (2.3)
				return new TagSummary { TimestampStart = startTag.Timestamp, TimestampEnd = endTag.Timestamp, Tag = startTag.Tag };
			});
		 
			return result;
		})
		.SelectMany(x => x); // Step (3)
	Console.WriteLine("timestamp_start     | timestamp_end       | tag      | nrOfSeconds");
	foreach (var summary in summaries)
		Console.WriteLine($"{summary.TimestampStart:yyyy-MM-dd HH:mm:ss} | {summary.TimestampEnd:yyyy-MM-dd HH:mm:ss} | {summary.Tag,-8} | {summary.TimeSpan.TotalSeconds:0}");
