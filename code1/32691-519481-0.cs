			List<int> list = new List<int> ();
			List<int> clone = new List<int> (list);
			list.Add (new int ());
			Debug.Assert (list != clone);
			Debug.Assert (list.Count == 1);
			Debug.Assert (clone.Count == 0);
This code is perfectly working as intended for me. Are you maybe changing the objects IN the list? The list items <b>won't</b> get cloned by new List(oldList).
