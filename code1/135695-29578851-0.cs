    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Func<double, double, double, double, double> newTonLaw = (m1, m2, r, g) => ((m1 * m2) / Math.Pow(r,2)) * g;
    
                // Mass of Earth= 5.98 * 10e24 , Gravitational Constant = 6.6726 * 10e-11
                Func<double, double, double> onEarth = (m2, r) => newTonLaw.Invoke(5.98 * 10e24, m2, r, 6.6726*10e-11);
    
                // Mass of Moon= 7.348x10e22 , Gravitational Constant = 6.6726 * 10e-11
                Func<double, double, double> onMoon = (m2, r) => newTonLaw.Invoke(7.348 * 10e22, m2, r, 6.6726 * 10e-11);
    
                Trace.WriteLine(onEarth(70, 6.38 * 10e6)); // result 686.203545562642
                Trace.WriteLine(onMoon(70, 6.38 * 10e6)); // result 8.43181212841855
            }
        }
    }
