            string[,] arr = new string[,] {
                { "Hello", "World", "Foo", "Bar" },
                { null,    null,    null,  null },
                { null,    null,    null,  null },
                { "Hello", "World", "Foo", "Bar" },
                {null, null, "Foo", "Bar" }
            };
            IList<string[]> l = new List<string[]>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string[] aux = new string[arr.GetLength(1)];
                bool isNull = true;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    aux[j] = arr[i, j];
                    isNull &= (aux[j] == null);
                }
                if (!isNull)
                    l.Add(aux);
            }
