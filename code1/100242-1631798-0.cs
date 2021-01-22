    using System;
    
    namespace CodeFreezer.CodeSamples
    {
        public static class ExpressionEvaluator
        {
            /// <summary>
            /// Evaluate
            /// Evaluate a math expression
            /// </summary>
            /// <param name="expression">Expression to evaluate</param>
            /// <returns>result</returns>
            public static double Evaluate(string expression)
            {
                if (String.IsNullOrEmpty(expression)) throw new ArgumentNullException("expression");
    
                return Convert.ToDouble(Microsoft.JScript.Eval.JScriptEvaluate(expression, Microsoft.JScript.Vsa.VsaEngine.CreateEngine()));
            }
        }
    }
