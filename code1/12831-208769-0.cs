    using System;
    using System.CodeDom.Compiler;
    using System.Globalization;
    using System.Reflection;
    using Microsoft.JScript;
    
    namespace Common.Rule
    {
      internal static class ExpressionEvaluator
      {
        #region static members
        private static object _evaluator = GetEvaluator();
        private static Type _evaluatorType;
        private const string _evaluatorSourceCode =
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
    
        #endregion
    
        #region static methods
        private static object GetEvaluator()
        {
          CompilerParameters parameters;
          parameters = new CompilerParameters();
          parameters.GenerateInMemory = true;
    
          JScriptCodeProvider jp = new JScriptCodeProvider();
          CompilerResults results = jp.CompileAssemblyFromSource(parameters, _evaluatorSourceCode);
    
          Assembly assembly = results.CompiledAssembly;
          _evaluatorType = assembly.GetType("Evaluator.Evaluator");
    
          return Activator.CreateInstance(_evaluatorType);
        }
    
        /// <summary>
        /// Executes the passed JScript Statement and returns the string representation of the result
        /// </summary>
        /// <param name="statement">A JScript statement to execute</param>
        /// <returns>The string representation of the result of evaluating the passed statement</returns>
        public static string EvaluateToString(string statement)
        {
          object o = EvaluateToObject(statement);
          return o.ToString();
        }
    
        /// <summary>
        /// Executes the passed JScript Statement and returns the result
        /// </summary>
        /// <param name="statement">A JScript statement to execute</param>
        /// <returns>The result of evaluating the passed statement</returns>
        public static object EvaluateToObject(string statement)
        {
          lock (_evaluator)
          {
            return _evaluatorType.InvokeMember(
                        "Eval",
                        BindingFlags.InvokeMethod,
                        null,
                        _evaluator,
                        new object[] { statement },
                        CultureInfo.CurrentCulture
                     );
          }
        }
        #endregion
      }    
    }
