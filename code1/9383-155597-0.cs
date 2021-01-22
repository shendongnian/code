        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var f_oType = Type.GetTypeFromProgID("Project1.Class1");
                var f_oInstance = Activator.CreateInstance(f_oType);
                f_oType.InvokeMember("Test3", BindingFlags.InvokeMethod, null, f_oInstance, new object[] {});
            }
            catch(TargetInvocationException ex)
            {
                //no need to subtract -2147221504 if non custom error etc
                int errorNumber = ((COMException)ex.InnerException).ErrorCode - (-2147221504);
                MessageBox.Show(errorNumber.ToString() + ": " + ex.InnerException.Message);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
