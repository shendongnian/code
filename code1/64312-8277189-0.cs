    public class HtmlAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    
        public HtmlAttribute(string name) : this(name, null) { }
    
        public HtmlAttribute(
            string name,
            string @value)
        {
            this.Name = name;
            this.Value = @value;
        }
    
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Value))
                return this.Name;
    
            if (this.Value.Contains('"'))
                return string.Format("{0}='{1}'", this.Name, this.Value);
    
            return string.Format("{0}=\"{1}\"", this.Name, this.Value);
        }
    }
    
    public class HtmlElement
    {
        protected List<HtmlAttribute> Attributes { get; set; }
        protected List<object> Childs { get; set; }
        public string Name { get; set; }
        protected HtmlElement Parent { get; set; }
    
        public HtmlElement() : this(null) { }
    
        public HtmlElement(string name, params object[] childs)
        {
            this.Name = name;
            this.Attributes = new List<HtmlAttribute>();
            this.Childs = new List<object>();
    
            if (childs != null && childs.Length > 0)
            {
                foreach (var c in childs)
                {
                    Add(c);
                }
            }
        }
    
        public void Add(object o)
        {
            var a = o as HtmlAttribute;
            if (a != null)
                this.Attributes.Add(a);
            else
            {
                var h = o as HtmlElement;
                if (h != null && !string.IsNullOrEmpty(this.Name))
                {
                    h.Parent = this;
                    this.Childs.Add(h);
                }
                else
                    this.Childs.Add(o);
            }
        }
    
        public override string ToString()
        {
            var result = new StringBuilder();
    
            if (!string.IsNullOrEmpty(this.Name))
            {
                result.Append(string.Format("<{0}", this.Name));
                if (this.Attributes.Count > 0)
                {
                    result.Append(" ");
                    foreach (var attr in this.Attributes)
                    {
                        result.Append(attr.ToString());
                        result.Append(" ");
                    }
    
                    result = new StringBuilder(result.ToString().TrimEnd(' '));
                }
    
                if (this.Childs.Count == 0)
                {
                    result.Append(" />");
                }
                else
                {
                    result.AppendLine(">");
    
                    foreach (var c in this.Childs)
                    {
                        var cParts = c.ToString().Split('\n');
    
                        foreach (var p in cParts)
                        {
                            result.AppendLine(string.Format("{0}", p));
                        }
                    }
    
                    result.Append(string.Format("</{0}>", this.Name));
                }
            }
            else
            {
                foreach (var c in this.Childs)
                {
                    var cParts = c.ToString().Split('\n');
    
                    foreach (var p in cParts)
                    {
                        result.AppendLine(string.Format("{0}", p));
                    }
                }
            }
    
            var head = GetHeading(this);
    
            var ps = result.ToString().Split('\n');
            return string.Join("\r\n", (from p in ps select head + p.TrimEnd('\r')).ToArray());
        }
    
        string GetHeading(HtmlElement h)
        {
            if (h.Parent != null)
                return "    ";
            else
                return string.Empty;
        }
    }
