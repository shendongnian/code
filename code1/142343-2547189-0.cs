    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    namespace ConsoleApplication3
    {
    class Program
    {
        private enum MyEnum
        {
            shwan,
            dooo,
            sieven,
            sieven_haif,
            shwenty,
            shwenty_doo_haif,
            schfifty_faive
        }
        class EnumInfo
        {
            public MyEnum Enum;
            public bool State;
            public override bool  Equals(object obj)
            {
                EnumInfo ei = obj as EnumInfo;
                return this.Enum == ei.Enum && this.State == ei.State;
            }
            public override int GetHashCode()
            {
                return this.Enum.GetHashCode() ^ this.State.GetHashCode();
            }
        }
        private static IDictionary<EnumInfo, Color> EnumColorDict = new Dictionary<EnumInfo, Color>()
            {
                {new EnumInfo(){Enum=MyEnum.shwan, State=true},Color.LimeGreen},
                {new EnumInfo(){Enum=MyEnum.shwan, State=false},Color.Red},
                {new EnumInfo(){Enum=MyEnum.dooo, State=true},Color.LimeGreen},
                {new EnumInfo(){Enum=MyEnum.dooo, State=false},Color.Red}
            };
        static void Main(string[] args)
        {
            EnumInfo ei = new EnumInfo() { Enum = MyEnum.shwan, State = true };
            Color c = EnumColorDict[ei];
        }
    }
    }
