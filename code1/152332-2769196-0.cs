		  public static IEnumerable<T> mergeSortedEnumerables<T>(
				this IEnumerable<IEnumerable<T>> listOfLists, 
				Func<T, T, Boolean> func)
		  {
				IEnumerable<T> l1 = new List<T>{};
				foreach (var l in listOfLists)
				{
					 l1 = l1.mergeTwoSorted(l, func);
				}
				
				foreach (var t in l1)
				{
					 yield return t;
				}
		  }
		  public static IEnumerable<T> mergeTwoSorted<T>(
				this IEnumerable<T> l1, 
				IEnumerable<T> l2, 
				Func<T, T, Boolean> func)
		  {
				using (var enumerator1 = l1.GetEnumerator())
				using (var enumerator2 = l2.GetEnumerator())
				{
					 bool enum1 = enumerator1.MoveNext();
					 bool enum2 = enumerator2.MoveNext();
					 while (enum1 || enum2)
					 {
						  T t1 = enumerator1.Current;
						  T t2 = enumerator2.Current;
						  //if they are both false
						  if (!enum1 && !enum2)
						  {
								break;
						  }
						  //if enum1 is false
						  else if (!enum1)
						  {
								enum2 = enumerator2.MoveNext();
								yield return t2;
								
						  }
						  //if enum2 is false
						  else if (!enum2)
						  {
								enum1 = enumerator1.MoveNext();
								yield return t1;
								
						  }
						  //they are both true
						  else
						  {
								//if func returns true then t1 < t2
								if (func(t1, t2))
								{
									 enum1 = enumerator1.MoveNext();
									 yield return t1;
									 
								}
								else
								{
									 enum2 = enumerator2.MoveNext();
									 yield return t2;
									 
								}
						  }
					 }
				}
		  }
