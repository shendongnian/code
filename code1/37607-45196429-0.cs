    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace GClass1
    {
    [Guid("D6F88E95-8A27-4ae6-B6DE-0542A0FC7039")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _GesGasConnect
    {
        [DispId(1)]
        int SetClass1Ver(string version);
     
    }
    [Guid("13FE32AD-4BF8-495f-AB4D-6C61BD463EA4")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("InterfacesSMS.Setting")]
    public class Class1 : _Class1
    {
        public Class1() { }
        public int SetClass1(string version)
        {
            return (DateTime.Today.Day);
        }
    }
    }
