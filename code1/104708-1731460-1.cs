    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using NVelocity;
    using NVelocity.App;
    
    namespace MyProgram
    {
        /// <summary>
        /// A wrapper for the NVelocity template processor
        /// </summary>
        public class NVelocityEngine : VelocityEngine
        {
            Hashtable context = new Hashtable();
    
            /// <summary>
            /// A list of values to be merged with the template
            /// </summary>
            public Hashtable Context
            {
                get { return context; }
            }
    
            /// <summary>
            /// Default constructor
            /// </summary>
            public NVelocityEngine()
            {
                base.Init();
            }
    
            /// <summary>
            /// Renders a template by merging it with the context items
            /// </summary>
            public string Render(string template)
            {
                VelocityContext nvContext;
    
                nvContext = new VelocityContext(context);
                using (StringWriter writer = new StringWriter())
                {
                    this.Evaluate(nvContext, writer, "template", template);
                    return writer.ToString();
                }
            }
        }
    }
