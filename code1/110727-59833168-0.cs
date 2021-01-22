class GraphicsDevice: IGraphicsDevice {
    public void DoWork() {
        Console.WriteLine("GraphicsDevice.DoWork()");
    }
}
// with its interface
interface IGraphicsDevice {
    void DoWork();
}
// You can't just override DoWork in a child class,
// but if you replace usage of GraphicsDevice to IGraphicsDevice,
// then you can override this method (and, actually, the whole interface).
class MyDevice: GraphicsDevice, IGraphicsDevice {
    public new void DoWork() {
        Console.WriteLine("MyDevice.DoWork()");
        base.DoWork();
    }
}
And here's demo
class Program {
    static void Main(string[] args) {
        IGraphicsDevice real = new GraphicsDevice();
        var myObj = new MyDevice();
        // demo that interface override works
        GraphicsDevice myCastedToBase = myObj;
        IGraphicsDevice my = myCastedToBase;
        // obvious
        Console.WriteLine("Using real GraphicsDevice:");
        real.DoWork();
        // override
        Console.WriteLine("Using overriden GraphicsDevice:");
        my.DoWork();
    }
}
