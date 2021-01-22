    using System;
    using System.Collections.Generic;
    /// <summary>
    /// TTE Node types.
    /// </summary>
    public enum E_TTE_NODES
    {
        /// <summary>
        /// Represents FCM 0
        /// </summary>
        E_FCM0 = 0,
        /// <summary>
        /// Represents FCM 1
        /// </summary>
        E_FCM1,
        /// <summary>
        /// Represents FCM 2
        /// </summary>
        E_FCM2,
        /// <summary>
        /// Represents DCM 0
        /// </summary>
        E_DCM0,
        /// <summary>
        /// Represents DCM 1
        /// </summary>
        E_DCM1,
        /// <summary>
        /// Represents DCM 2
        /// </summary>
        E_DCM2,
        /// <summary>
        /// Represents CCM 0
        /// </summary>
        E_CCM0,
        /// <summary>
        /// Represents CCM 1
        /// </summary>
        E_CCM1,
        /// <summary>
        /// Represents CCM 2
        /// </summary>
        E_CCM2,
        /// <summary>
        /// Represents PDU C1
        /// </summary>
        E_PDU_C1,
        /// <summary>
        /// Represents the last node.
        /// Must remain last.
        /// </summary>
        E_LAST,
    }
    public class Example
    {
        private List<Int32> transmitIndex = new List<Int32>((Int32) E_TTE_NODES.E_LAST);
        public static void Main()
        {
            Example example = new Example();
            Console.WriteLine(example.transmitIndex.Capacity);
            Console.ReadKey();
        }
    }
