    //for adding multiple elements to a collection that doesn't have AddRange
    //e.g., collection.Add(item1, item2, itemN);
    static void Add<T>(this ICollection<T> coll, params T[] items)
     { foreach (var item in items) coll.Add(item);
     }
    //like string.Format() but with custom string representation of arguments
    //e.g., "{0} {1} {2}".Format<Custom>(c=>c.Name,"string",new object(),new Custom())
    //      result: "string {System.Object} Custom1Name"
    static string Format<T>(this string format, Func<T,object> select, params object[] args)
     { for(int i=0; i < args.Length; ++i)
        { var x = args[i] as T;
          if (x != null) args[i] = select(x);
        }
       return string.Format(format, args);
     }
