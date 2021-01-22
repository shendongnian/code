        private static int Count(HtmlNodeCollection nc) {
            return nc == null ? 0 : nc.Count;
        }
        private static void BuildList(HtmlNode node, ref List<HtmlNode> list) {
            var sortedNodes = from n in node.ChildNodes
                              orderby Count(n.SelectNodes(".//a[@href and img]")) descending
                              select n;
            foreach (var n in sortedNodes) {
                if (n.Name == "a") list.Add(n);
                else if (n.HasChildNodes) BuildList(n, ref list);
            }
        }
