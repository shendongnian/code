    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var la = new List<AssetDocument> { new AssetDocument() {AssetID = 1} };
                var result = la.ToCSVList(l => l.AssetID.ToString());
            }
        }
        public class AssetDocument
        {
        	public int AssetID { get; set; }
        }
        public static class GlobalExtensions
        {
        	public static string ToCSVList<T>(this List<T> list, Func<T, string> propResolver)
        	{
                var sb = new StringBuilder(list.Count * 36 + list.Count);
                var delimiter = "";
                foreach (var document in list)
                {
                    sb.Append(delimiter);
                    sb.Append(propResolver(document));
                    delimiter = ",";
                }
                return sb.ToString();
        	}
        }
    }
