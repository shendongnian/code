          public IEnumerable<item> GetMyList()
        {
            foreach (var x in thirdParty )
            {
                if (x == ignore)
                    continue;
                yield return x;
            }
 
        }
