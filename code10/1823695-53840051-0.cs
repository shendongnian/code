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
