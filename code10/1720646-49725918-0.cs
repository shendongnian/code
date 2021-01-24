    class Program
    {
        static void Main(string[] args)
        {
            int Id = 1;
            var data = Get(Id).Select(a => new ODataProperty
            {
                Size = a.Type == "Asset"
                    ? GetSize(a.AssetInfo.Size)
                    : null
            });
            var summedSize = data.Sum(a => a.Size);
            // with your values summedSize is summedSize kilobyte
        }
        private static int? GetSize(string assetInfoSize)
        {
            // Implement some logic that will get your sizes out of the string.
            // Use some base unit e.g. all Values must be kb
            // so you need to convert all data to kb
            // 2 Gigabyte = 2000000 kilobyte
            // 4 MB = 4000 kilobyte
            // 6 KB = 6 kilobyte
            if (assetInfoSize == null)
            {
                return null;
            }
            var sizePart = assetInfoSize.Substring(0, assetInfoSize.Length - 2);
            var unitPart = assetInfoSize.Substring(assetInfoSize.Length - 2);
            if (unitPart.ToLower() == "gb")
            {
                return int.Parse(sizePart) * 1000000;
            }
            if (unitPart.ToLower() == "mb")
            {
                return int.Parse(sizePart) * 1000;
            }
            if (unitPart.ToLower() == "kb")
            {
                return int.Parse(sizePart);
            }
            throw new NotImplementedException();
        }
        public static List<SomeObject> Get(int id)
        {
            // Returning some sample values
            return new List<SomeObject>
            {
                new SomeObject()
                {
                    Type = "Asset",
                    AssetInfo = new AssetInfo
                    {
                        Size = "2Gb"
                    }
                },
                new SomeObject()
                {
                    Type = "Asset",
                    AssetInfo = new AssetInfo
                    {
                        Size = "4MB"
                    }
                },
                new SomeObject()
                {
                    Type = "Asset",
                    AssetInfo = new AssetInfo
                    {
                        Size = "6KB"
                    }
                }
            };
        }
    }
    internal class ODataProperty
    {
        public int? Size { get; set; }
    }
    internal class AssetInfo
    {
        public string Size { get; set; }
    }
    internal class SomeObject
    {
        public string Type { get; set; }
        public AssetInfo AssetInfo { get; set; }
    }
