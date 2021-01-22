    public interface IScanner
    {
        void Scan(IPart part);
    }
    public interface IPart
    {
        string ID { get; }
    }
    [ScannedPart("your-id-for-A")]
    public class AlphaScanner : IScanner
    {
        public void Scan(IPart part)
        {
            throw new NotImplementedException();
        }
    }
    [ScannedPart("your-id-for-B")]
    public class BetaScanner : IScanner
    {
        public void Scan(IPart part)
        {
            throw new NotImplementedException();
        }
    }
    public interface IComposite
    {
        List<IPart> Parts { get; }
    }
    public class ScannerDriver
    {
        public Dictionary<string, IScanner> Scanners { get; private set; }
        public void DoScan(IComposite composite)
        {
            foreach (IPart part in composite.Parts)
            {
                IScanner scanner = Scanners[part.ID];
                scanner.Scan(part);
            }
        }
    }
