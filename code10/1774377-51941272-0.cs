    using System.Collections;
    using PX.Data;
    using PX.Objects.AR;
    using PX.Objects.SO;
    namespace PXDemoPkg
    {
        public class SOShipmentEntryPXExt : PXGraphExtension<SOShipmentEntry>
        {
            public PXAction<SOShipment> DummyCustomAction;
            [PXButton()]
            [PXUIField(DisplayName = "Dummy Custom Action",
                       MapEnableRights = PXCacheRights.Select,
                       MapViewRights = PXCacheRights.Select)]
            protected virtual IEnumerable dummyCustomAction(PXAdapter adapter)
            {
                SOShipment shipment = Base.Document.Current;
                SOOrderShipment soOrderShipment = PXSelect<SOOrderShipment,
                                                        Where<SOOrderShipment.shipmentNbr, Equal<Required<SOOrderShipment.shipmentNbr>>>>.
                                                        Select(Base, shipment.ShipmentNbr);
                ARInvoice arInvoice = PXSelect<ARInvoice, Where<ARInvoice.refNbr, Equal<Required<ARInvoice.refNbr>>,
                                                            And<ARInvoice.docType, Equal<Required<ARInvoice.docType>>>>>.
                                                            Select(Base, soOrderShipment.InvoiceNbr, "INV");
                PXLongOperation.StartOperation(Base, delegate ()
                {
                    SOInvoiceEntry soInvoiceGraph = PXGraph.CreateInstance<SOInvoiceEntry>();
                    SOShipmentEntry soShipmentGraph = PXGraph.CreateInstance<SOShipmentEntry>();
                    //Release Sales Invoice
                    soInvoiceGraph.Clear();
                    soInvoiceGraph.Document.Current = soInvoiceGraph.Document.Search<ARInvoice.docType, ARInvoice.refNbr>(arInvoice.DocType, arInvoice.RefNbr);
                    soInvoiceGraph.release.Press();
                    //Update IN on Shipment
                    soShipmentGraph.Clear();
                    soShipmentGraph.Document.Current = soShipmentGraph.Document.Search<SOShipment.shipmentNbr>(shipment.ShipmentNbr);
                    soShipmentGraph.UpdateIN.Press();
                });
                return adapter.Get();
            }
        }
    }
