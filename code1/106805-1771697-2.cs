        static IEnumerable<MyObj> MyFilter(IEnumerable<MyObj> input)
        {
            MyObj aux = input.First();
            yield return aux;
            foreach (var o in input.Skip(1))
            {
                if (o.DateStart > aux.DateEnd)
                {
                    aux = o;
                    yield return aux;
                }
            }
        }
