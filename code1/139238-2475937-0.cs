    public class ThirdPartyClass1 {
        public string Name {
            get {
                return "ThirdPartyClass1";
            }
        }
        public void DoThirdPartyStuff() {
            Console.WriteLine("ThirdPartyClass1 is doing its thing.");
        }
    }
    public interface IThirdPartyClassWrapper {
        public string Name { get; }
        public void DoThirdPartyStuff();
    }
    public class ThirdPartyClassWrapper1 : IThirdPartyClassWrapper {
        ThirdPartyClass1 _thirdParty;
        public string Name {
            get { return _thirdParty.Name; }
        }
        public void DoThirdPartyStuff() {
            _thirdParty.DoThirdPartyStuff();
        }
    }
