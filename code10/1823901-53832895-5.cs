    Console.WriteLine($"List Row Count = {list.Count()}"); 
	Console.WriteLine($"JoinList Row Count = {joinList.Count()}"); 
	
	var watch = Stopwatch.StartNew();
	var result = list.Join(joinList, l => l.Prop3, i=> i.Prop3, (lst, inner) => new {lst, inner})
	   .Where(t => t.inner.Prop3 == "Prop13")
	   .Select(t => new { t.inner.Prop4, t.lst.Prop2});	
	result.Dump();
	watch.Stop();
	
	Console.WriteLine($"Result1 Elapsed = {watch.ElapsedTicks}");
	
	watch.Restart();
	var result2 = list
	   .Where(t => t.Prop3 == "Prop13")
	   .Join(joinList, l => l.Prop3, i=> i.Prop3, (lst, inner) => new {lst, inner})
	   .Select(t => new { t.inner.Prop4, t.lst.Prop2});
	
	result2.Dump();
    watch.Stop();
	Console.WriteLine($"Result2 Elapsed = {watch.ElapsedTicks}"); 
	
	watch.Restart();
	var result3 = list.AsQueryable().Join(joinList, l => l.Prop3, i=> i.Prop3, (lst, inner) => new {lst, inner})
	   .Where(t => t.inner.Prop3 == "Prop13")
	   .Select(t => new { t.inner.Prop4, t.lst.Prop2});	
	result3.Dump();
	watch.Stop();
	Console.WriteLine($"Result3 Elapsed = {watch.ElapsedTicks}"); 
