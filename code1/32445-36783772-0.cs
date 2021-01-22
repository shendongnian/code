    == ChemicalFactory.cs ==
    partial class ChemicalFactory {
        private  ChemicalFactory() {}
        public interface IChemical {
            int AtomicNumber { get; }
        }
        public static IChemical CreateOxygen() {
            return new Oxygen();
        }
    }
    == Oxygen.cs ==
    partial class ChemicalFactory {
        private class Oxygen : IChemical {
            public Oxygen() {
                AtomicNumber = 8;
            }
            public int AtomicNumber { get; }
        }
    }
    == Program.cs ==
    class Program {
        static void Main(string[] args) {
            var ox = ChemicalFactory.CreateOxygen();
            Console.WriteLine(ox.AtomicNumber);
        }
    }
