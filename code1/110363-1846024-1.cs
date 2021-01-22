    // ClassLibrary1.dll
    //SomeClass.cs
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Windows.Forms;
    using LogNamespace;
    
    public class SomeClass
    {
        [Import("Logging", typeof(ILogger))]
        public ILogger Log { get; set; } //<-- ALWAYS NULL ???
    
        public SomeClass()
        {
            var catalog = new AggregateCatalog();
            CompositionContainer _container;
    
            // catalog.Catalogs.Add(new DirectoryCatalog("."));
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));
            _container = new CompositionContainer(catalog);
    
            _container.ComposeParts(this);
        }
    
        public void Print()
        {
            Log.Print();
        }
    
    }
    
    // ClassLibrary1.dll
    // LoggerImpl.cs
    namespace ClassLibrary1
    {
        [Export("Logging", typeof(ILogger))]
        public class LoggerImpl : ILogger
        {
            public void Print()
            {
                Console.WriteLine("print called");
            }
        }
    }
    
    // ClassLibrary2.dll
    // ILogger.cs
    namespace LogNamespace
    {
        public interface ILogger
        {
            void Print();
        }
    }
    
    // WindowsFormsApplication1.exe
    // WindowsFormsApplication1.cs
    namespace WindowsFormsApplication1
    {
        [Export("Form1", typeof(Form1))]
        public partial class Form1 : Form
        {
    
            [Import("Logging", typeof(ILogger))]
            public ILogger Log { set; get; }
    
            private CompositionContainer _container;
    
            public Form1()
            {
                InitializeComponent();
                Compose();
                Log.Print();
    
                SomeClass c = new SomeClass();
                c.Print();
            }
    
            private void Compose()
            {
                var catalog = new AggregateCatalog();
    
                // catalog.Catalogs.Add(new DirectoryCatalog("."));
                catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));
                _container = new CompositionContainer(catalog);
    
                try
                {
                    _container.ComposeParts(this);
                }
                catch (CompositionException compositionException)
                {
                    MessageBox.Show(compositionException.ToString());
                }
            }
        }
    }
