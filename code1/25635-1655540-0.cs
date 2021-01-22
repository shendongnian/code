        using System.Runtime.Interopservices;
        [Guid("00024500-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        interface IExcel
        {
          // sample property
          string Name{get;}
          // more properties
        }
        
        // and somewhere else
        void main()
        {
          Object xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
          IExcel excel = (IExcel)xl;
          string name = xl.name
        }
