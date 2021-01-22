    enter code here:static T? TryParse<T>(string parse)
            where T : struct
        {
            Type t=typeof(T);
            if (t==typeof(int))
            {
                int i;
                if (int.TryParse(parse, out i))
                    return (T)(object)i;
                return null;
                //Console.WriteLine(t.Name);
            }
            if (t == typeof(double))
            {
                double i;
                if (double.TryParse(parse, out i))
                    return (T)(object)i;
                return null;
            }
            //blabla, more logic like datetime and other data types
            return null;
        }
