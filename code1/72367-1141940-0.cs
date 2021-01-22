    namespace TypeTest{
        public interface IMultiTextProvider {
            bool Insert(string text, Guid campaignId);
        }
        public class BonusProvider : IMultiTextProvider {
            public bool Insert(string text, Guid campaignId) {
                return true;
            }
        }
        class Program {
            static void Main(string[] args) {
                string typeName = "TypeTest.BonusProvider";
                Type providerType = Type.GetType(typeName);
                IMultiTextProvider provider = Activator.CreateInstance(providerType)
                    as IMultiTextProvider;
                if (null == provider) {
                    throw new ArgumentException("ProviderType does not implement IMultiTextProvider interface");
                }
                Console.WriteLine(provider.Insert("test",new Guid()));
            }
        }
    }
