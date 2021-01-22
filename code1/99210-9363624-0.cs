    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    
    namespace MEFHelper
    {
        public static class MEFImporter
        {
            #region Catalog Field
    
            private readonly static AggregateCatalog _catalog;
    
            public static AggregateCatalog Catalog { get { return _catalog; } }
    
            #endregion
    
            static MEFImporter()
            {
                //An aggregate catalog that combines multiple catalogs
                _catalog = new AggregateCatalog();
                //Adds all the parts found in all assemblies in 
                //the same directory as the executing program
                _catalog.Catalogs.Add(
                    new DirectoryCatalog(
                        System.IO.Path.GetDirectoryName(new Uri(
                        System.Reflection.Assembly.GetExecutingAssembly()
                        .CodeBase).AbsolutePath)
                ));
            }
    
            /// <summary>
            ///  Fill the imports of this object
            /// </summary>
            /// <param name="obj">Object to fill the Imports</param>
            /// <param name="contructorParameters">MEF contructor parameters</param>
            /// <remarks>Use for MEF importing</remarks>
            public static void DoImport(this object obj, params MEFParam[] contructorParameters)
            {
                //Create the CompositionContainer with the parts in the catalog
                CompositionContainer container = new CompositionContainer(Catalog, true);
    
                //Add the contructor parameters
                if (contructorParameters != null && contructorParameters.Length > 0) 
                {
                    foreach (MEFParam mefParam in contructorParameters)
                        if (mefParam != null && mefParam.Parameter != null) mefParam.Parameter(container);
                }
    
                //Fill the imports of this object
                container.ComposeParts(obj);
            }
    
            #region MEFParam
    
            /// <summary>
            /// Creates a Mef Param to do the Import
            /// </summary>
            /// <typeparam name="T">Type of the value to store</typeparam>
            /// <param name="value">Value to store</param>
            /// <param name="key">Optional MEF label</param>
            /// <returns>A MEF paramameter</returns>
            /// <remarks>This retuns a MEF encapsulated parameter in a delegate</remarks>
            public static MEFParam Parameter<T>(T value, string key = null)
            {
                Action<CompositionContainer> param;
                if (string.IsNullOrWhiteSpace(key)) 
                    param = p => p.ComposeExportedValue(value);
                else param = p => p.ComposeExportedValue(key, value);
                return new MEFParam(param);
            }
    
            /// <summary>
            /// Mef Param to do the Import
            /// </summary>
            public class MEFParam
            {
                protected internal MEFParam(Action<CompositionContainer> param)
                {
                    this.Parameter = param;
                }
                public Action<CompositionContainer> Parameter { get; private set; }
            }
    
            #endregion
    
        }
    }
