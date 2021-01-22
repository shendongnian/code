    public static class Extender
    {
        public static Dictionary<string, string> ToDictionary(this StringCollection sc)
        {
            if (sc.Count % 2 != 0) throw new InvalidDataException("Broken dictionary");
            var dic = new Dictionary<string, string>();
            for (var i = 0; i < sc.Count; i += 2)
            {
                dic.Add(sc[i], sc[i + 1]);
            }
            return dic;
        }
        public static StringCollection ToStringCollection(this Dictionary<string, string> dic)
        {
            var sc = new StringCollection();
            foreach (var d in dic)
            {
                sc.Add(d.Key);
                sc.Add(d.Value);
            }
            return sc;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var sc = new StringCollection();
            //sc.Add("Key01");
            //sc.Add("Val01");
            //sc.Add("Key02");
            //sc.Add("Val02");
            var sc = Settings.Default.SC;
            var dic = sc.ToDictionary();
            var sc2 = dic.ToStringCollection();
            Settings.Default.SC = sc2;
            Settings.Default.Save();
        }
    }
