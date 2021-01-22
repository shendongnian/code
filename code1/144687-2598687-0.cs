    public static class ControlExtensions {
        public static void changeStatus(this Control varControl, bool varState) {
            if (varControl.InvokeRequired) {
                varControl.BeginInvoke(new MethodInvoker(() => changeStatus(varControl, varState)));
            } else {
                varControl.Enabled = varState;
            }
        }
        public static void changeText(this Control varControl, string varText) {
            if (varControl.InvokeRequired) {
                varControl.BeginInvoke(new MethodInvoker(() => changeText(varControl, varText)));
            } else {
                varControl.Text = varText;
            }
        }
        public static DateTime readDateValue(this DateTimePicker varControl) {
            if (varControl.InvokeRequired) {
                return (DateTime) varControl.Invoke(new Func<DateTime>(() => readDateValue(varControl)));
            } else {
                return varControl.Value;
            }
        }
        public static bool ReadStatus(this CheckBox varControl) {
            if (varControl.InvokeRequired) {
                return (bool) varControl.Invoke(new Func<bool>(() => ReadStatus(varControl)));
            }
            return varControl.Checked;
        }
        public static bool ReadStatus(this RadioButton varControl) {
            if (varControl.InvokeRequired) {
                return (bool) varControl.Invoke(new Func<bool>(() => ReadStatus(varControl)));
            }
            return varControl.Checked;
        }
        public static string readText(this Control varControl) {
            if (varControl.InvokeRequired) {
                return (string) varControl.Invoke(new Func<string>(() => readText(varControl)));
            } else {
                return varControl.Text;
            }
        }
        public static bool readEnabled(this Control varControl) {
            if (varControl.InvokeRequired) {
                return (bool) varControl.Invoke(new Func<bool>(() => readEnabled(varControl)));
            } else {
                return varControl.Enabled;
            }
        }
        
    }
