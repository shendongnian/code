    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.JScript;
 
      public class JScriptEvaluator
      {
            public   int EvalToInteger(string statement)
            {
                  string s = EvalToString(statement);
                  return int.Parse(s.ToString());
            }
            public   double EvalToDouble(string statement)
            {
                  string s = EvalToString(statement);
                  return double.Parse(s);
            }
            public   string EvalToString(string statement)
            {
                object o = "-1";
                try
                {
                 o=  EvalToObject(statement);
                }
                catch { o = "-1"; }
                  return o.ToString();
            }
            public   object EvalToObject(string statement)
            {
                  return _evaluatorType.InvokeMember(
                                    "Eval",
                                    BindingFlags.InvokeMethod,
                                    null,
                                    _evaluator,
                                    new object[] { statement }
                              );
            }
            public JScriptEvaluator()
            {
                  CodeDomProvider provider = new Microsoft.JScript.JScriptCodeProvider();
                  CompilerParameters parameters;
                  parameters = new CompilerParameters();
                  parameters.GenerateInMemory = true;
                  CompilerResults results;
                  results = provider.CompileAssemblyFromSource(parameters, _jscriptSource);
                  Assembly assembly = results.CompiledAssembly;
                  _evaluatorType = assembly.GetType("Evaluator.Evaluator");
                  _evaluator = Activator.CreateInstance(_evaluatorType);
            }
            private   object _evaluator = null;
            private   Type _evaluatorType = null;
            private   readonly string _jscriptSource =
                  @"package Evaluator
                  {
                     class Evaluator
                     {
                           public function Eval(expr : String) : String 
                           { 
                              return eval(expr); 
                           }
                     }
                  }";
      }
 
