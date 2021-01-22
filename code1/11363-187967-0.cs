    public static class Helpers
    {
        public static List&lt;T&gt; CollectionToList&lt;T&gt;(this System.Collections.ICollection other)
        {
            var output = new List&lt;T&gt;(other.Count);
            output.AddRange(other.Cast&lt;T&gt;());
            return output;
        }
    }
