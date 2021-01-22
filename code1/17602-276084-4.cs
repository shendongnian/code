        private ReverserService() { }
        /// <summary>
        /// Most importantly uses yield command for efficiency
        /// </summary>
        /// <param name="enumerableInstance"></param>
        /// <returns></returns>
        public static IEnumerable ToReveresed(IEnumerable enumerableInstance)
        {
            if (enumerableInstance == null)
            {
                throw new ArgumentNullException("enumerableInstance");
            }
            // First we need to move forwarad and create a temp
            // copy of a type that allows us to move backwards
            // We can use ArrayList for this as the concrete
            // type
            IList reversedEnumerable = new ArrayList();
            IEnumerator tempEnumerator = enumerableInstance.GetEnumerator();
            while (tempEnumerator.MoveNext())
            {
                reversedEnumerable.Add(tempEnumerator.Current);
            }
            // Now we do the standard reverse over this using yield to return
            // the result
            // NOTE: This is an immutable result by design. That is 
            // a design goal for this simple question as well as most other set related 
            // requirements, which is why Linq results are immutable for example
            // In fact this is foundational code to understand Linq
            for (var i = reversedEnumerable.Count - 1; i >= 0; i--)
            {
                yield return reversedEnumerable[i];
            }
        }
    }
    public static class ExtensionMethods
    {
        
          public static IEnumerable ToReveresed(this IEnumerable enumerableInstance)
          {
              return ReverserService.ToReveresed(enumerableInstance);
          }
     }
