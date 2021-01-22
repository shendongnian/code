using System.IO;
using log4net;
using log4net.Config;
using log4net.ObjectRenderer;
using log4net.Util;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            
            ILog log = LogManager.GetLogger(typeof(Program));
            var repo = LogManager.GetRepository();
            repo.RendererMap.Put(typeof(Foo), new FooRenderer());
            var fooInstance = new Foo() { Name = "Test Foo" };
            log.Info(fooInstance);
        }
    }
    internal class Foo
    {
        public string Name { get; set; }
    }
    internal class FooRenderer : log4net.ObjectRenderer.IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            if (obj == null)
            {
                writer.Write(SystemInfo.NullText);
            }
            var fooInstance = obj as Foo;
            if (fooInstance != null)
            {
                writer.Write("<[Foo instance named {0}]>", fooInstance.Name);
            }
            else
            {
                writer.Write(SystemInfo.NullText);
            }
        }
    }
}
