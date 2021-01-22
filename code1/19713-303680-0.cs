    public class CBar
    {
        CBar()
        {
            m_pFoo = new CFoo();
        }
        CFoo m_pFoo;
        private class CFoo
        {
            CFoo()
            {
                // Do stuff
            }
        }
    }
