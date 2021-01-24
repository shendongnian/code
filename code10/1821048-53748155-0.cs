            var cadImage =(CadImage) Aspose.CAD.Image.Load("filePath");
            CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
            rasterizationOptions.Layouts = new string[] { "Model" };
            rasterizationOptions.NoScaling = true;
            // note: preserving some empty borders around part of image is the responsibility of customer
            // top left point of region to draw
            Point topLeft = new Point(6156, 7053);
            double width = 3108;
            double height = 2489;
            CadVportTableObject newView = new CadVportTableObject();
            newView.Name = new CadStringParameter();
            newView.Name.Init("*Active");
            newView.CenterPoint.X = topLeft.X + width / 2f;
            newView.CenterPoint.Y = topLeft.Y - height / 2f;
            newView.ViewHeight.Value = height;
            newView.ViewAspectRatio.Value = width / height;
            for (int i = 0; i < cadImage.ViewPorts.Count; i++)
            {
                CadVportTableObject currentView = (CadVportTableObject)(cadImage.ViewPorts[i]);
                if (cadImage.ViewPorts.Count == 1 || string.Equals(currentView.Name.Value.ToLowerInvariant(), "*active"))
                {
                    cadImage.ViewPorts[i] = newView;
                    break;
                }
            }
            cadImage.Save("Saved.pdf", new Aspose.CAD.ImageOptions.PdfOptions() { VectorRasterizationOptions = rasterizationOptions });
