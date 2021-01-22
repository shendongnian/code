        public static string RemoveAllNamespaces(XElement element)
        {
            string tex = element.ToString();
            var nsitems = element.DescendantsAndSelf().Select(n => n.ToString().Split(' ', '>')[0].Split('<')[1]).Where(n => n.Contains(":")).DistinctBy(n => n).ToArray();
            //Namespace prefix on nodes: <a:nodename/>
            tex = nsitems.Aggregate(tex, (current, nsnode) => current.Replace("<"+nsnode + "", "<" + nsnode.Split(':')[1] + ""));
            tex = nsitems.Aggregate(tex, (current, nsnode) => current.Replace("</" + nsnode + "", "</" + nsnode.Split(':')[1] + ""));
            //Namespace attribs
            var items = element.DescendantsAndSelf().SelectMany(d => d.Attributes().Where(a => a.IsNamespaceDeclaration || a.ToString().Contains(":"))).DistinctBy(o => o.Value);
            tex = items.Aggregate(tex, (current, xAttribute) => current.Replace(xAttribute.ToString(), ""));
          
            return tex;
        }
