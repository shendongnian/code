	var newList1 = list1.Where(l1 => list2.Any(l2 => l2.Id == l1.Id))
						.Select(l1 => new Class1 
						{
							Id = l1.Id,
							Flag = true,
						})
						.ToList();
