            string body = content;
            string [] param = {"&"};
            string[] anotherParam = { "=" };
            string[] str = body.Split(param , StringSplitOptions.RemoveEmptyEntries);
            System.Collections.Hashtable table = new System.Collections.Hashtable();
            foreach (string item in table)
            {
                string[] arr = item.ToString().Split(anotherParam, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    table.Add(arr[0], arr[1]);
                }
                catch { }
            }
