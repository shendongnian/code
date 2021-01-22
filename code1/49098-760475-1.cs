    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using Microsoft.CSharp;
    
    namespace Dynamo
    {
      public static class DynamicCodeManager
      {
        #region internal statics and constants
        static Dictionary<string, string> _conditionSnippet = new Dictionary<string, string>();
        static Dictionary<string, string> _methodSnippet = new Dictionary<string, string>();
        static string CodeStart = "using System;\r\nusing System.Collections.Generic;\r\n//using System.Linq;\r\nusing System.Text;\r\nusing System.Data;\r\nusing System.Reflection;\r\nusing System.CodeDom.Compiler;\r\nusing Microsoft.CSharp;\r\nnamespace Dynamo\r\n{\r\n  public class Dynamic : DynamicBase\r\n  {\r\n";
        static string DynamicConditionPrefix = "__dm_";
        static string ConditionTemplate = "    bool {0}{1}(params object[] p) {{ return {2}; }}\r\n";
        static string MethodTemplate = "    object {0}(params object[] p) {{\r\n{1}\r\n    }}\r\n";
        static string CodeEnd = "  }\r\n}";
        static List<string> _references = new List<string>("System.dll,System.dll,System.Data.dll,System.Xml.dll,mscorlib.dll,System.Windows.Forms.dll".Split(new char[] { ',' }));
        static Assembly _assembly = null;
        #endregion
    
        public static Assembly Assembly { get { return DynamicCodeManager._assembly; } }
    
        #region manage snippets
        public static void Clear()
        {
          _methodSnippet.Clear();
          _conditionSnippet.Clear();
          _assembly = null;
        }
        public static void Clear(string name)
        {
          if (_conditionSnippet.ContainsKey(name))
          {
            _assembly = null;
            _conditionSnippet.Remove(name);
          }
          else if (_methodSnippet.ContainsKey(name))
          {
            _assembly = null;
            _methodSnippet.Remove(name);
          }
        }
    
        public static void AddCondition(string conditionName, string booleanExpression)
        {
          if (_conditionSnippet.ContainsKey(conditionName))
            throw new InvalidOperationException(string.Format("There is already a condition called '{0}'", conditionName));
          StringBuilder src = new StringBuilder(CodeStart);
          src.AppendFormat(ConditionTemplate, DynamicConditionPrefix, conditionName, booleanExpression);
          src.Append(CodeEnd);
          Compile(src.ToString()); //if the condition is invalid an exception will occur here
          _conditionSnippet[conditionName] = booleanExpression;
          _assembly = null;
        }
    
        public static void AddMethod(string methodName, string methodSource)
        {
          if (_methodSnippet.ContainsKey(methodName))
            throw new InvalidOperationException(string.Format("There is already a method called '{0}'", methodName));
          if (methodName.StartsWith(DynamicConditionPrefix))
            throw new InvalidOperationException(string.Format("'{0}' is not a valid method name because the '{1}' prefix is reserved for internal use with conditions", methodName, DynamicConditionPrefix));
          StringBuilder src = new StringBuilder(CodeStart);
          src.AppendFormat(MethodTemplate, methodName, methodSource);
          src.Append(CodeEnd);
          Trace.TraceError("SOURCE\r\n{0}", src);
          Compile(src.ToString()); //if the condition is invalid an exception will occur here
          _methodSnippet[methodName] = methodSource;
          _assembly = null;
        }
        #endregion
    
        #region use snippets
        public static object InvokeMethod(string methodName, params object[] p)
        {
          DynamicBase _dynamicMethod = null;
          if (_assembly == null)
          {
            Compile();
            _dynamicMethod = _assembly.CreateInstance("Dynamo.Dynamic") as DynamicBase;
          }
          return _dynamicMethod.InvokeMethod(methodName, p);
        }
    
        public static bool Evaluate(string conditionName, params object[] p)
        {
          DynamicBase _dynamicCondition = null;
          if (_assembly == null)
          {
            Compile();
            _dynamicCondition = _assembly.CreateInstance("Dynamo.Dynamic") as DynamicBase;
          }
          return _dynamicCondition.EvaluateCondition(conditionName, p);
        }
    
        public static double Transform(string functionName, params object[] p)
        {
          DynamicBase _dynamicCondition = null;
          if (_assembly == null)
          {
            Compile();
            _dynamicCondition = _assembly.CreateInstance("Dynamo.Dynamic") as DynamicBase;
          }
          return _dynamicCondition.Transform(functionName, p);
        }
        #endregion
    
        #region support routines
        public static string ProduceConditionName(Guid conditionId)
        {
          StringBuilder cn = new StringBuilder();
          foreach (char c in conditionId.ToString().ToCharArray()) if (char.IsLetterOrDigit(c)) cn.Append(c);
          string conditionName = cn.ToString();
          return string.Format("_dm_{0}",cn);
        }
        private static void Compile()
        {
          if (_assembly == null)
          {
            StringBuilder src = new StringBuilder(CodeStart);
            foreach (KeyValuePair<string, string> kvp in _conditionSnippet)
              src.AppendFormat(ConditionTemplate, DynamicConditionPrefix, kvp.Key, kvp.Value);
            foreach (KeyValuePair<string, string> kvp in _methodSnippet)
              src.AppendFormat(MethodTemplate, kvp.Key, kvp.Value);
            src.Append(CodeEnd);
            Trace.TraceError("SOURCE\r\n{0}", src);
            _assembly = Compile(src.ToString());
          }
        }
        private static Assembly Compile(string sourceCode)
        {
          CompilerParameters cp = new CompilerParameters();
          cp.ReferencedAssemblies.AddRange(_references.ToArray());
          cp.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);
          cp.CompilerOptions = "/target:library /optimize";
          cp.GenerateExecutable = false;
          cp.GenerateInMemory = true;
          CompilerResults cr = (new CSharpCodeProvider()).CompileAssemblyFromSource(cp, sourceCode);
          if (cr.Errors.Count > 0) throw new CompilerException(cr.Errors);
          return cr.CompiledAssembly;
        }
        #endregion
    
        public static bool HasItem(string methodName)
        {
          return _conditionSnippet.ContainsKey(methodName) || _methodSnippet.ContainsKey(methodName);
        }
      }
    }
