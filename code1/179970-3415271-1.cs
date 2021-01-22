        for (int i = 0; i < nvc.Count; i++)
        {
            if (nvc.GetValues(i).Length > 1)
            {
                for (int x = 0; x < nvc.GetValues(i).Length; x++)
                {
                    Console.WriteLine("'{0}' = '{1}'", nvc.GetKey(i), nvc.GetValues(i).GetValue(x));
                }
            }
            else
            {
                Console.WriteLine("'{0}' = '{1}'", nvc.GetKey(i), nvc.GetValues(i)[0]);
            }
        }
