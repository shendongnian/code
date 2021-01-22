        LocalValueEnumerator propEnumerator = foo.GetLocalValueEnumerator();
        while (propEnumerator.MoveNext())
        {
            Console.WriteLine ("{0} = {1}",
                               propEnumerator.Current.Property.Name,
                               propEnumerator.Current.Value);
        }
