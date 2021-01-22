    private int length;
 	 
 	public List<List<string>> Generate(List<string> list)
        {
             length = list.Count;
             List<List<string>> results = new List<List<string>>();
             Generate(list, ref results);
 
             return results;
        }
        
 	private List<List<string>> Generate(List<string> list, ref List<List<string>> results)
        {
            List<List<string>> subperms = new List<List<string>>();
            if (list.Count <= 1)
            {
                subperms.Add(list);
                return subperms;
            }
            for (int i = 0; i < list.Count; i++)
            {
                string temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                List<string> tail = new List<string>(list);
                tail.RemoveAt(0);
                List<string> head = new List<string>();
                head.Add(list[0]);
                foreach (List<string> subperm in Generate(tail, ref results))
                {
                    List<string> headCopy = new List<string>(head);
                    headCopy.AddRange(subperm);
                    if (headCopy.Count == length)
                        results.Add(headCopy);
                    else
                        subperms.Add(headCopy);
                }
                temp = list[0];
                list[0] = list[i];
                list[i] = temp;
            }
            return subperms;
        }
