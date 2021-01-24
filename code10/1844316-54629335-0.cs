    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Printing;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Xps;
    using System.Windows.Xps.Packaging;
    namespace Services.Printing
    {
        public static class PrintingService
        {
            public static void Print(Visual elementToPrint, string description)
            {
                using (var printServer = new LocalPrintServer())
                {
                    var dialog = new PrintDialog();
                    var queue = printServer.DefaultPrintQueue;
                    dialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
                    dialog.PrintQueue = queue;
                    dialog.PrintVisual(elementToPrint, description);
                }
            }
        }
    }
