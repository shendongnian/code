    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RGiesecke.DllExport;
    
    namespace MyFirstRDSSpy_Plugin
    {
        public class Class1
        {
            static unsafe TRDSGroup* P_RDSGroup;
        public struct TRDSGroup
    {
            public ushort Year;
            public byte Month;
            public byte Day;
            public byte Hour;
            public byte Minutes;
            public byte Second;
            public byte Centisecond;
            public ushort RFU;
            public int Blk1;
            public int Blk2;
            public int Blk3;
            public int Blk4;
        }
        static int PI;
        static TRDSGroup Group;
        [DllExport("RDSGroup", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        unsafe static void RDSGroup(TRDSGroup* PRDSGroup)
        {
            Group = *PRDSGroup;
            if (Group.Blk1 >= 0)
            {
                if (PI != Group.Blk1) {
                    PI = Group.Blk1;
                    System.Windows.Forms.MessageBox.Show("New PI has been detected:" + PI.ToString("X4"));
                }
            }
        }
        [DllExport("Command", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        static void Command(string Cmd, string Param)
        {
            var w = "";
            w = Cmd.ToUpper();
            if (w == "CONFIGURE")
            {
                System.Windows.Forms.MessageBox.Show("Nothing to configure in this simple plugin.");
            }
            if (w == "RESETDATA")
            {
                PI = -1;
            }
        }
        [DllExport("PluginName", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        static string PluginName()
            {
            return "My First Plugin";
            }
        }
    }
