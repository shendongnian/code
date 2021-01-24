    public partial class AttackMatrixView : UserControl
    {
        public Sides AttackingSide = Sides.Red;
        public Sides DefendingSide = Sides.Blue;
        public AttackMatrixView()
        {
            Resources.Add("AttackerSide", AttackingSide);
            Resources.Add("DefenderSide", DefendingSide);
            InitializeComponent();
            XElement col = GetXElement(@"pack://application:,,,/Views/AttackFactors/attackFactorColumn.txt");
            foreach (UnitTypes ut in  Enum.GetValues(typeof(UnitTypes)).Cast<UnitTypes>().Where(x=>x.ThisFights()==true).Select(x=>x).ToList())
            {
                XElement el = new XElement(col);
                string colString = el.ToString()
                    .Replace("^^^Index^^^", ((int)ut).ToString())
                    .Replace("^^^EnumString^^^", ut.ToString())
                    .Replace("^^^EnumDescription^^^", ut.ToDescriptionString());
                ParserContext context = new ParserContext();
                context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
                DataGridTextColumn tc = (DataGridTextColumn)XamlReader.Parse(colString, context);
                dg.Columns.Add(tc);
            };
        }
        private XElement GetXElement(string uri)
        {
            XDocument xmlDoc = new XDocument();
            var xmltxt = Application.GetContentStream(new Uri(uri));
            string elfull = new StreamReader(xmltxt.Stream).ReadToEnd();
            xmlDoc = XDocument.Parse(elfull);
            return xmlDoc.Root;
        }
    }
