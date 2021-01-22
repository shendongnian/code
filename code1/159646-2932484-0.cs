public class SecondForm : Form
{
       public static m_myInstance= new SecondForm();
       public static bool m_visible = false;
       public SecondForm ()
       {
              InitializeComponent()               
       }
       public SecondForm Instance()
       {
            return m_myInstance;
       }
       
      public static void Show()
      {
          ...
      }
} 
