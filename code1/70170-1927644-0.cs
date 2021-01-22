    private KeyMessageFilter m_filter = new KeyMessageFilter();
    private void Form1_Load(object sender, EventArgs e)
    {
        Application.AddMessageFilter(m_filter);
 
    }
    public class KeyMessageFilter : IMessageFilter
    {
        private Dictionary<Keys, bool> m_keyTable = new Dictionary<Keys, bool>();
    
        public Dictionary<Keys, bool> KeyTable
        {
            get { return m_keyTable; }
            private set { m_keyTable = value; }
        }
    
        public bool IsKeyPressed()
        {
            return m_keyPressed; 
        }
    
        public bool IsKeyPressed(Keys k)
        {
            bool pressed = false;
    
            if (KeyTable.TryGetValue(k, out pressed))
            {
                return pressed;                  
            }
    
            return false; 
        }
    
        private const int WM_KEYDOWN = 0x0100;
    
        private const int WM_KEYUP = 0x0101;
    
        private bool m_keyPressed = false;
    
    
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                KeyTable[(Keys)m.WParam] = true;
    
                m_keyPressed = true;
            }
    
            if (m.Msg == WM_KEYUP)
            {                
                KeyTable[(Keys)m.WParam] = false;
    
                m_keyPressed = false;
            }
    
            return false;
        }
    }
