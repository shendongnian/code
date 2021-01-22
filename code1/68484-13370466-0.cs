    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Reflection;
    using IronPython.Hosting;
    using IronPythonMef;
    public interface IMessenger
    {
        string GetMessage();
    }
    public interface IConfig
    {
        string Intro { get; }
    }
    /// <summary>
    /// Gets exported from IronPython into the CLR Demo instance.
    /// </summary>
    public static class PythonScript
    {
        public static readonly string Code =
    @"
    @export(IMessenger)
    class PythonMessenger(IMessenger):
        def GetMessage(self):
            return self.config.Intro + ' from IronPython'
        @import_one(IConfig)
        def import_config(self, config):
            self.config = config
    ";
    }
    /// <summary>
    /// Also gets exported into the Demo instance.
    /// </summary>
    [Export(typeof(IMessenger))]
    public class ClrMessenger : IMessenger
    {
        [Import(typeof(IConfig))]
        public IConfig Config { get; set; }
        public string GetMessage()
        {
            return Config.Intro + " from C#!";
        }
    }
    /// <summary>
    /// This will get imported into both the IronPython class and ClrMessenger.
    /// </summary>
    [Export(typeof(IConfig))]
    public class Config : IConfig
    {
        public string Intro
        {
            get { return "Hello"; }
        }
    }
    public class Demo
    {
        [ImportMany(typeof(IMessenger))]
        public IEnumerable<IMessenger> Messengers { get; set; }
        public Demo()
        {
            // Create IronPython
            var engine = Python.CreateEngine();
            var script = engine.CreateScriptSourceFromString(PythonScript.Code);
            // Configure the engine with types
            var typesYouWantPythonToHaveAccessTo = new[] { typeof(IMessenger), typeof(IConfig) };
            var typeExtractor = new ExtractTypesFromScript(engine);
            var exports = typeExtractor.GetPartsFromScript(script,
                typesYouWantPythonToHaveAccessTo);
            // Compose with MEF
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch(exports, new ComposablePart[] { });
            container.Compose(batch);
            container.SatisfyImportsOnce(this);
        }
        public static void Main(string[] args)
        {
            var demo = new Demo();
            foreach (var messenger in demo.Messengers)
            {
                Console.WriteLine(messenger.GetMessage());
            }
            Console.Read();
        }
    }
