    public interface IIdentifiable {
        int Id { get; }
    }
    public class Repository<T> where T : class, IIdentifiable {
        TestDataContext dataContext = new TestDataContext();
        public T GetById(int id) {
            T t = dataContext.GetTable<T>().SingleOrDefault(elem => elem.Id.Equals(id));
            return t;
        }
    }
    public partial class Item : IIdentifiable {
    }
    class Program {
        static void Main(string[] args) {
            Repository<Item> itemRepository = new Repository<Item>();
            Item item = itemRepository.GetById(1);
            Console.WriteLine(item.Text);
        }
    }
