    public class CloseWindowBehavior : IMessageFilter {
    
        const int WM_KEYDOWN = 0x100;
        const int VK_ESCAPE = 0x1B;
    
        bool IMessageFilter.PreFilterMessage(ref Message m) {
            if (m.Msg == WM_KEYDOWN && (int)m.WParam == VK_ESCAPE) {
                if (Form.ActiveForm != null) {
                    Form.ActiveForm.Close();
                }
                return true;
            }
            return false;
        }
    
    }
    
    Application.AddMessageFilter(new CloseWindowBehavior());
