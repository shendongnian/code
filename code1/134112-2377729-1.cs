    namespace WpfApplication1
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = from i in Enumerable.Range(0, 10)
                          select new DistributorContainer()
                          {
                              ID = i,
                              Distributor1 = new Distributor() { Name = String.Format("Distributor1 Name{0}", i) },
                              Distributor2 = new Distributor() { Name = String.Format("Distributor2 Name{0}", i) }
                          };
        }
    }
    public class DistributorContainer
    {
        public int ID { get; set; }
        public Distributor Distributor1 { get; set; }
        public Distributor Distributor2 { get; set; }
    }
    public class Distributor
    {
        public string Name { get; set; }
    }
