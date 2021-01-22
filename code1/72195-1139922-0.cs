    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using CSScriptLibrary;
    
    namespace RulesEngine
    {
        /// <summary>
        /// Make sure <typeparamref name="T"/> is an interface, not just any type of class.
        /// 
        /// Should be enforced by the compiler, but just in case it's not, here's your warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class RulesEngine<T> where T : class
        {
            public RulesEngine(string rulesScriptFileName, string classToInstantiate)
                : this()
            {
                if (rulesScriptFileName == null) throw new ArgumentNullException("rulesScriptFileName");
                if (classToInstantiate == null) throw new ArgumentNullException("classToInstantiate");
    
                if (!File.Exists(rulesScriptFileName))
                {
                    throw new FileNotFoundException("Unable to find rules script", rulesScriptFileName);
                }
    
                RulesScriptFileName = rulesScriptFileName;
                ClassToInstantiate = classToInstantiate;
    
                LoadRules();
            }
    
            public T @Interface;
    
            public string RulesScriptFileName { get; private set; }
            public string ClassToInstantiate { get; private set; }
            public DateTime RulesLastModified { get; private set; }
    
            private RulesEngine()
            {
                @Interface = null;
            }
    
            private void LoadRules()
            {
                if (!File.Exists(RulesScriptFileName))
                {
                    throw new FileNotFoundException("Unable to find rules script", RulesScriptFileName);
                }
    
                FileInfo file = new FileInfo(RulesScriptFileName);
    
                DateTime lastModified = file.LastWriteTime;
    
                if (lastModified == RulesLastModified)
                {
                    // No need to load the same rules twice.
                    return;
                }
    
                string rulesScript = File.ReadAllText(RulesScriptFileName);
    
                Assembly compiledAssembly = CSScript.LoadCode(rulesScript, null, true);
    
                @Interface = compiledAssembly.CreateInstance(ClassToInstantiate).AlignToInterface<T>();
    
                RulesLastModified = lastModified;
            }
        }
    }
