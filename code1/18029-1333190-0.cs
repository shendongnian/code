    internal void QuickActivate(UnsafeNativeMethods.tagQACONTAINER pQaContainer, UnsafeNativeMethods.tagQACONTROL pQaControl)
    {
        int num;
        this.LookupAmbient(-701).Value = ColorTranslator.FromOle((int) pQaContainer.colorBack);
        this.LookupAmbient(-704).Value = ColorTranslator.FromOle((int) pQaContainer.colorFore);
        if (pQaContainer.pFont != null)
        {
            Control.AmbientProperty ambient = this.LookupAmbient(-703);
            IntSecurity.UnmanagedCode.Assert();
            try
            {
                Font font2 = Font.FromHfont(((UnsafeNativeMethods.IFont) pQaContainer.pFont).GetHFont());
                ambient.Value = font2;
            }
            catch (Exception exception)
            {
                if (ClientUtils.IsSecurityOrCriticalException(exception))
                {
                    throw;
                }
                ambient.Value = null;
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
        }
        pQaControl.cbSize = UnsafeNativeMethods.SizeOf(typeof(UnsafeNativeMethods.tagQACONTROL));
        this.SetClientSite(pQaContainer.pClientSite);
        if (pQaContainer.pAdviseSink != null)
        {
            this.SetAdvise(1, 0, (IAdviseSink) pQaContainer.pAdviseSink);
        }
        IntSecurity.UnmanagedCode.Assert();
        try
        {
            ((UnsafeNativeMethods.IOleObject) this.control).GetMiscStatus(1, out num);
        }
        finally
        {
            CodeAccessPermission.RevertAssert();
        }
        pQaControl.dwMiscStatus = num;
        if ((pQaContainer.pUnkEventSink != null) && (this.control is UserControl))
        {
            Type defaultEventsInterface = GetDefaultEventsInterface(this.control.GetType());
            if (defaultEventsInterface != null)
            {
                IntSecurity.UnmanagedCode.Assert();
                try
                {
                    **AdviseHelper.AdviseConnectionPoint(this.control, pQaContainer.pUnkEventSink, defaultEventsInterface, out pQaControl.dwEventCookie);**
                }
                catch (Exception exception2)
                {
                    if (ClientUtils.IsSecurityOrCriticalException(exception2))
                    {
                        throw;
                    }
                }
                finally
                {
                    CodeAccessPermission.RevertAssert();
                }
            }
        }
        if ((pQaContainer.pPropertyNotifySink != null) && UnsafeNativeMethods.IsComObject(pQaContainer.pPropertyNotifySink))
        {
            UnsafeNativeMethods.ReleaseComObject(pQaContainer.pPropertyNotifySink);
        }
        if ((pQaContainer.pUnkEventSink != null) && UnsafeNativeMethods.IsComObject(pQaContainer.pUnkEventSink))
        {
            UnsafeNativeMethods.ReleaseComObject(pQaContainer.pUnkEventSink);
        }
    }
