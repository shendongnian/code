         var asyncBagTask = new List<Task>();
			var ConcurrentlistXls = new ConcurrentBag<ReporteXlsPippPrfE>();
	       
			foreach (var records in findItem)
			{
				asyncBagTask.Add(Task.Run(() =>
				{
					
						var item = _plantillaPippBs.GetXlsProformaEpsByCveShcp(records.ftClaveCarteraSHCP);
						if (item != null)
						{
							ConcurrentlistXls.Add(item);
						}
					
					
				}));
			}
	      Task.WaitAll(asyncBagTask.ToArray());
 
