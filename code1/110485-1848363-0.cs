    public interface IController
    {
        string GetById(int id);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mockController = new Mock<IController>();
            mockController.Setup(x => x.GetById(1)).Returns("one");
            mockController.Setup(x => x.GetById(2)).Returns("two");
            mockController.Setup(x => x.GetById(3)).Returns("three");
            IController controller = mockController.Object;
            Console.WriteLine(controller.GetById(1));
            Console.WriteLine(controller.GetById(3));
            Console.WriteLine(controller.GetById(2));
            Console.WriteLine(controller.GetById(3));
            Console.WriteLine(controller.GetById(99) == null);
        }
    }
