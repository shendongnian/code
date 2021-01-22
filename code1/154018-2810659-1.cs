    namespace Fragments
    {
        class Line
        {
            private readonly static Regex Pattern =
                new Regex(@"^(?<X>X[^Y]+?)(?<Y>Y[^Z]+?)(?<Z>Z[^G]+?)(?<G>G[^H]+?)(?<H>H[^E]+?)(?<E>E[^$])$");
    
            public readonly string OriginalText;
    
            public string Text
            {
                get
                {
                    return this.X.ToString() + this.Y.ToString() + this.G54.ToString() + this.G.ToString() + this.T.ToString() + Environment.NewLine +
                           this.G43.ToString() + this.Z.ToString() + this.H.ToString() + this.M08.ToString();
                }
            }
    
            public readonly bool IsMatch;
    
            public Fragment X { get; set; }
            public Fragment Y { get; set; }
            public readonly Fragment G54 = new Fragment("G54");
            public Fragment G { get; set; }
            public Fragment T { get; set; }
            public readonly Fragment G43 = new Fragment("G43");
            public Fragment Z { get; set; }
            public Fragment H { get; set; }
            public readonly Fragment M08 = new Fragment("M08");
            public Fragment E { get; set; }
    
            public Line(string text)
            {
                this.OriginalText = text;
                Match match = Line.Pattern.Match(text);
                this.IsMatch = match.Success;
    
                if (match.Success)
                {
                    this.X = new Fragment(match.Groups["X"].Value);
                    this.Y = new Fragment(match.Groups["Y"].Value);
                    this.G = new Fragment(match.Groups["G"].Value);
                    this.Z = new Fragment(match.Groups["Z"].Value);
                    this.H = new Fragment(match.Groups["H"].Value);
                    this.E = new Fragment(match.Groups["E"].Value);
    
                    this.T = new Fragment('T', this.H.Number + 1.0);
                }
            }
    
            public override string ToString()
            {
                return this.Text;
            }
        }
    }
