    public class MouseDevice {
        public delegate void ButtonClickedHandler<O, E>(O sender, E e);
    }
    
    public interface IClickable<O,E> {
        event MouseDevice.ButtonClickedHandler<O,E> Clicked;
    }
    
    public class MouseTest : IClickable<Control,MouseEventArgs>
    {
    
        public event MouseDevice.ButtonClickedHandler<Control, MouseEventArgs> Clicked;
    
        public static void main(string[] args) {
            MouseTest m = new MouseTest();
            m.Clicked += new MouseDevice.ButtonClickedHandler<Control, MouseEventArgs>(m_Clicked);
        }
    
        static void m_Clicked(Control sender, MouseEventArgs e)
        {
            //Handle Click Event...
        }
    }
