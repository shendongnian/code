            WIA.CommonDialog wiaDlg;
            WIA.Device wiaDevice;
            WIA.DeviceManager wiaManager = new DeviceManager();
            wiaDlg = new WIA.CommonDialog();
            wiaDevice = wiaDlg.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
            foreach (WIA.Item item in wiaDevice.Items)
            {
                StringBuilder propsbuilder = new StringBuilder();
                foreach (WIA.Property itemProperty in item.Properties)
                {
                    IProperty tempProperty;
                    Object tempNewProperty;
                    if (itemProperty.Name.Equals("Horizontal Resolution"))
                    {
                        tempNewProperty = 75;
                        ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                    }
                    else if (itemProperty.Name.Equals("Vertical Resolution"))
                    {
                        tempNewProperty = 75;
                        ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                    }
                    else if (itemProperty.Name.Equals("Horizontal Extent"))
                    {
                        tempNewProperty = 619;
                        ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                    }
                    else if (itemProperty.Name.Equals("Vertical Extent"))
                    {
                        tempNewProperty = 876;
                        ((IProperty)itemProperty).set_Value(ref tempNewProperty);
                    }
                }
                image = (ImageFile)item.Transfer(WIA.FormatID.wiaFormatPNG);
            }
