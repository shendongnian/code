    #region File Header
    // This file Copyright © 2007 Lasse Vågsæther Karlsen, All rights reserved.
    //
    // $Id: GCLog.cs 135 2008-05-28 11:28:37Z lassevk $
    #endregion
    
    #region Using
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using Gurock.SmartInspect;
    
    #endregion
    
    namespace PresentationMode
    {
        /// <summary>
        /// This class is used to get a running log of the number of garbage collections that occur,
        /// when running with logging.
        /// </summary>
        public sealed class GCLog
        {
            #region Construction & Destruction
    
            /// <summary>
            /// Releases unmanaged resources and performs other cleanup operations before the
            /// <see cref="GCLog"/> is reclaimed by garbage collection.
            /// </summary>
            ~GCLog()
            {
                SiAuto.Main.LogMessage("GARBAGE COLLECTED");
                if (!AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
                    new GCLog();
            }
    
            #endregion
    
            #region Public Static Methods
    
            /// <summary>
            /// Registers this instance.
            /// </summary>
            public static void Register()
            {
    #if DEBUG
                if (SiAuto.Si.Enabled)
                    new GCLog();
    #endif
            }
    
            #endregion
        }
    }
