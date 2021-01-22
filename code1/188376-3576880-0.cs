    class KeyboardShortcuts
    {
        public static void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (m_keysDownList.Contains(e.Key) == false)
            {
                m_keysDownList.Add(e.Key);
                Debug.WriteLine(e.Key.ToString() + " Down");
            }
 
            CheckForKeyCombos();
        }
 
        public static void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            m_keysDownList.Remove(e.Key);
            Debug.WriteLine(e.Key.ToString() + " Up");
        }
 
 
        public static void CheckForKeyCombos()
        {
            if (m_keysDownList.Contains(System.Windows.Input.Key.LeftCtrl))
            {
                if (m_keysDownList.Contains(System.Windows.Input.Key.A))
                {
                    if (m_keysDownList.Contains(System.Windows.Input.Key.C))
                    {
                        // Clear list before handeling ( Dialogue boxes
                        // can hinder the listening for key up events, leaving
                        // keys in list - so clear first ).
                        ClearKeysDownList();
 
                        // Handle Ctrl + A + C Combo
                        HandleCtrlACCombo();
                    }
                }
            }
        }
 
        private static void ClearKeysDownList()
        {               
            m_keysDownList.Clear();
        }
 
        public static void HandleCtrlACCombo()
        {
            if (handleCtrlACComboDelegate != null)
            {
                handleCtrlACComboDelegate();
            }
        }
            
        // Need a delegate instance for each combo 
        public delegate void HandleCtrlACComboDelegate();
        public static HandleCtrlACComboDelegate handleCtrlACComboDelegate;
        private static List<System.Windows.Input.Key> m_keysDownList = new List<System.Windows.Input.Key>();
    }
 
