    static string Fix(string item, int count)
            {
                var chars = item.ToList().GroupBy(g => g).Select(s => new { Ch = s.Key.ToString(), Count = s.Count() }).Where(w => w.Count < count).ToList();
                var characters = string.Join("", item.ToList().Select(s => s.ToString()).Where(wi => chars.Any(a => a.Ch == wi)).ToList());
                return characters;
            }
