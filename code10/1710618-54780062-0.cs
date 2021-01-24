            PrintDialog dlg = new PrintDialog();
            if ((bool)dlg.ShowDialog().GetValueOrDefault()) {
                //switch landscape
                dlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                
                //get selected printer capabilities
                System.Printing.PrintCapabilities capabilities = dlg.PrintQueue.GetPrintCapabilities(dlg.PrintTicket);
                
                //get scale of the print wrt to screen of WPF visual
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight /  this.ActualHeight);
                //Transform the Visual to scale
                this.LayoutTransform = new ScaleTransform(scale, scale);
                //get the size of the printer page
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
                //update the layout of the visual to the printer page size.
                this.Measure(sz);
                this.Arrange(new Rect(new System.Windows.Point((int)capabilities.PageImageableArea.OriginWidth, (int)capabilities.PageImageableArea.OriginHeight), sz));
                //show the print dialog
                dlg.PrintVisual(this, "MyDoc_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            }
