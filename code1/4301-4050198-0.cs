    using System;
    using Microsoft.JScript;
    using Microsoft.JScript.Vsa;
    using Convert = Microsoft.JScript.Convert;
    namespace System
    {
        public class MathEvaluator : INeedEngine
        {
            private VsaEngine vsaEngine;
            public virtual String Evaluate(string expr)
            {
                var engine = (INeedEngine)this;
                var result = Eval.JScriptEvaluate(expr, engine.GetEngine());
                return Convert.ToString(result, true);
            }
            VsaEngine INeedEngine.GetEngine()
            {
                vsaEngine = vsaEngine ?? VsaEngine.CreateEngineWithType(this.GetType().TypeHandle);
                return vsaEngine;
            }
            void INeedEngine.SetEngine(VsaEngine engine)
            {
                vsaEngine = engine;
            }
        }
    }
