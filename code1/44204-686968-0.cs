    [SRDescription("ControlInvokeRequiredDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
            public bool InvokeRequired
            {
                get
                {
                    using (new MultithreadSafeCallScope())
                    {
                        HandleRef ref2;
                        int num;
                        if (this.IsHandleCreated)
                        {
                            ref2 = new HandleRef(this, this.Handle);
                        }
                        else
                        {
                            Control wrapper = this.FindMarshalingControl();
                            if (!wrapper.IsHandleCreated)
                            {
                                return false;
                            }
                            ref2 = new HandleRef(wrapper, wrapper.Handle);
                        }
                        int windowThreadProcessId = SafeNativeMethods.GetWindowThreadProcessId(ref2, out num);
                        int currentThreadId = SafeNativeMethods.GetCurrentThreadId();
                        return (windowThreadProcessId != currentThreadId);
                    }
                }
            }
