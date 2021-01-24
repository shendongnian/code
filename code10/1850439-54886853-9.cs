    services.AddMvc(op =>
    {
         foreach (var formatter in op.OutputFormatters
              .OfType<ODataOutputFormatter>())
         {
              formatter.BaseAddressFactory = ODataHelper.CustomBaseAddressFactory;
         }
         foreach (var formatter in op.InputFormatters
              .OfType<ODataInputFormatter>())
         {
              formatter.BaseAddressFactory = ODataHelper.CustomBaseAddressFactory;
         }
    });
