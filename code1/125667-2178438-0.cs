    [TypeConverter(typeof(ExpandableObjectConverter))]
    class Foo {
        private List<SyntaxRegex> _syntaxRegexList = new List<SyntaxRegex>();
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class SyntaxRegex
        {
           public override string ToString() {
               return string.IsNullOrEmpty(Title) ? "(no title)" : Title;
           }
           public string Title { get; set; }
           public string Regex { get; set; }
           public Color Color { get; set; }
        }
        [DisplayName("Patterns")]
        public List<SyntaxRegex> SyntaxRegexList
        {
            get { return _syntaxRegexList; }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form
            {
                Controls =
                {
                    new PropertyGrid { 
                        Dock = DockStyle.Fill,
                        SelectedObject = new Foo()
                    }
                }
            });
        }
    }
